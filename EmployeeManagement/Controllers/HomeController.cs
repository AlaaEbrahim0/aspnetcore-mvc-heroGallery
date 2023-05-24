using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Security;
using EmployeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    // [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ILogger logger;

        public HomeController(IEmployeeRepository repository, IWebHostEnvironment webHostEnvironment,
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
        public ViewResult List(string query = "")
        {
            var employeeList = _repository.GetAllEmployees();
            if (query != "")
            {
                employeeList = employeeList.Where(e => e.Name.ToLower().Contains(query.ToLower()));
            }
            return View(employeeList.ToList());
        }

        // [Route("{id?}")]
        [AllowAnonymous]
        [HttpGet]
        public ViewResult Details(int? id)
        {

            Employee employee = _repository.GetEmployee(id.Value);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }


            HomeDetailsViewModel viewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
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

        public ActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Gender = model.Gender,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };

                _repository.AddEmployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        //-----------------------------------------------------------------------

        [HttpGet]
        [Authorize]

        public ViewResult Edit(int? id)
        {
            Employee employee = _repository.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            EmployeeEditViewModel employeeEdit = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Gender = employee.Gender,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath,
            };

            return View(employeeEdit);
        }

        [HttpPost]
        [Authorize]

        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _repository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.Gender = model.Gender;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string path = Path.Combine(webHostEnvironment.WebRootPath, "imgs", model.ExistingPhotoPath);
                        System.IO.File.Delete(path);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                _repository.UpdateEmployee(employee);
                return RedirectToAction("Index");

            }
            return View(model);

        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult Delete(int id)
        {
            var emp = _repository.DeleteEmployee(id);
            if (emp == null)
            {
                ViewBag.ErrorMessage = $"Employee with ID = {id} cannot be found";
                return View("StatusCodeError");
            }
            return RedirectToAction("Index");
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
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