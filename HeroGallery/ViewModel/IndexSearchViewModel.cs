namespace HeroGallery.ViewModel;

public class IndexSearchViewModel
{
    [Required(ErrorMessage = "Please enter a search word")]
    public string SearchQuery { get; set; }
}