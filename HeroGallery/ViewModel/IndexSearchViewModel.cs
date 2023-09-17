using System.ComponentModel.DataAnnotations;

public class IndexSearchViewModel
{
    [Required(ErrorMessage = "Please enter a search word")]
    public string SearchQuery { get; set; }
}