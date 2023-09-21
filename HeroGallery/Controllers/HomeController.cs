namespace HeroGallery.Controllers;

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
    public ActionResult Index(IndexSearchViewModel? model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("List", new { query = model?.SearchQuery });
        }
        return View(model);
    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<ViewResult> ListAsync(int? page, string query = "")
    {
        int pageSize = 18;
        int pageNumber = page ?? 1;


        var HeroList = await _repository.GetAllHeros();
        var totalCount = HeroList.Count();


        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        if (pageNumber > totalPages)
        {
            pageNumber = 1;
        }

        if (query != "")
        {
            HeroList = HeroList.Where(e => e.Name.ToLower().Contains(query.ToLower()));
        }
        var paginatedData = HeroList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        var pagination = new Pagination<Hero>(paginatedData, pageNumber, pageSize, totalCount, totalPages);

        return View(pagination);
    }

    // [Route("{id?}")]
    [AllowAnonymous]
    [HttpGet]
    public async Task<ViewResult> DetailsAsync(int? id)
    {

	Hero Hero = await _repository.GetHero(id.Value);

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
    public async Task<ActionResult> CreateAsync(HeroCreateViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = await ProcessUploadedFileAsync(model);

                Hero newHero = new Hero
                {
                    Name = model.Name,
                    Gender = model.Gender,
                    Description = model.Description,
                    Power = model.Power,
                    Series = model.Series,
                    PhotoPath = uniqueFileName
                };

                await _repository.AddHero(newHero);
                return RedirectToAction("details", new { id = newHero.Id });
            }
            return View(model);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    //-----------------------------------------------------------------------

    [HttpGet]
    [Authorize]
    public async Task<ViewResult> EditAsync(int? id)
    {
        Hero Hero = await _repository.GetHero(id.Value);
        if (Hero is null)
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

    public async Task<IActionResult> EditAsync(HeroEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            Hero Hero = await _repository.GetHero(model.Id);
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
                Hero.PhotoPath = await ProcessUploadedFileAsync(model);
            }

            _repository.UpdateHero(Hero);
            return RedirectToAction("List");

        }
        return View(model);

    }

    [HttpPost]
    [Authorize(Roles = "Admin")]

    public IActionResult Delete(int id)
    {
        var emp = _repository.DeleteHero(id);
        if (emp == null)
        {
            ViewBag.ErrorMessage = $"Hero with ID = {id} cannot be found";
            return View("StatusCodeError");
        }
        return RedirectToAction("List");
    }

    private async Task<string> ProcessUploadedFileAsync(HeroCreateViewModel model)
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
		await model.Photo.CopyToAsync(stream);

        }

        return uniqueFileName;
    }


}