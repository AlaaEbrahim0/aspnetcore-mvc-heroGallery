using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HeroManagement.Models;
using HeroManagement.Security;
using HeroManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.Extensions.Logging;

namespace HeroManagement.Controllers
{
    // [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IHeroRepository _repository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger logger;

        public HomeController(IHeroRepository repository, IWebHostEnvironment webHostEnvironment,
            ILogger<HomeController> logger)
        {
            _repository = repository;
            this.webHostEnvironment = webHostEnvironment;
            this.logger = logger;
        }


        //[Route("")]
        //[Route("~/")]
        //[Route("~/Home")]
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new IndexSearchViewModel
            {
                SearchQuery = ""
            };

            return View(viewModel);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(IndexSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List", new { query = model.SearchQuery });
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult List(int? page, string query = "")
        {
            int pageSize = 12;
            int pageNumber = page ?? 1;


            var HeroList = _repository.GetAllHeros();
            var totalCount = HeroList.Count();


            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (pageNumber > totalPages)
            {
                pageNumber = 1;
            }

            var paginatedData = HeroList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var pagination = new Pagination<Hero>(paginatedData, pageNumber, pageSize, totalCount, totalPages);

            return View(pagination);
            if (query != "")
            {
                HeroList = HeroList.Where(e => e.Name.ToLower().Contains(query.ToLower()));
            }
            return View(HeroList.ToList());
        }

        // [Route("{id?}")]
        [AllowAnonymous]
        [HttpGet]
        public ViewResult Details(int? id)
        {

            Hero Hero = _repository.GetHero(id.Value);

            if (Hero == null)
            {
                Response.StatusCode = 404;
                return View("HeroNotFound", id.Value);
            }


            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Hero = Hero,
                PageTitle = "Hero Details"
            };

            return View(viewModel);

        }
        [HttpGet]
        [Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public ActionResult Create(HeroCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Hero newHero = new Hero
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Description = model.Description,
                    Power = model.Power,
                    Series = model.Series,
                    PhotoPath = uniqueFileName
                };

                _repository.AddHero(newHero);
                return RedirectToAction("details", new { id = newHero.Id });
            }
            return View(model);
        }

        //-----------------------------------------------------------------------

        [HttpGet]
        [Authorize]
        public ViewResult Edit(int? id)
        {
            Hero Hero = _repository.GetHero(id.Value);
            if (Hero == null)
            {
                Response.StatusCode = 404;
                return View("HeroNotFound", id.Value);
            }

            HeroEditViewModel HeroEdit = new HeroEditViewModel
            {
                Id = Hero.Id,
                Name = Hero.Name,
                Description = Hero.Description,
                Power = Hero.Power,
                Gender = Hero.Gender,
                Series = Hero.Series,
                ExistingPhotoPath = Hero.PhotoPath,
            };

            return View(HeroEdit);
        }

        [HttpPost]
        [Authorize]

        public IActionResult Edit(HeroEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hero Hero = _repository.GetHero(model.Id);
                Hero.Name = model.Name;
                Hero.Description = model.Description;
                Hero.Series = model.Series;
                Hero.Power = model.Power;
                Hero.Gender = model.Gender;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string path = Path.Combine(webHostEnvironment.WebRootPath, "imgs", model.ExistingPhotoPath);
                        System.IO.File.Delete(path);
                    }
                    Hero.PhotoPath = ProcessUploadedFile(model);
                }

                _repository.UpdateHero(Hero);
                return RedirectToAction("List");

            }
            return View(model);

        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult Delete(int id)
        {
            var emp = _repository.DeleteHero(id);
            if (emp == null)
            {
                ViewBag.ErrorMessage = $"Hero with ID = {id} cannot be found";
                return View("StatusCodeError");
            }
            return RedirectToAction("Index");
        }

        private string ProcessUploadedFile(HeroCreateViewModel model)
        {
            var photo = model.Photo;
            string uniqueFileName = null;


            if (photo != null)
            {
                string wwwroot = webHostEnvironment.WebRootPath;
                string imgs = Path.Combine(wwwroot, "imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string fullPath = Path.Combine(imgs, uniqueFileName);

                using var stream = new FileStream(fullPath, FileMode.Create);
                model.Photo.CopyTo(stream);

            }

            return uniqueFileName;
        }


    }

}