namespace HeroGallery.ViewModel;

public class HeroCreateViewModel
{

    [Required]
    public string Name { get; set; }

    [Required]
    public Gender? Gender { get; set; }

    [Required]
    public string Series { get; set; }

    [Required]
    public string Power { get; set; }

    [Required]
    public string Description { get; set; }

    public IFormFile Photo { get; set; }

}
