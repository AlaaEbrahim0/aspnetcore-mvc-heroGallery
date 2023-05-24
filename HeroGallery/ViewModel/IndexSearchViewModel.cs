using System.ComponentModel.DataAnnotations;

public class IndexSearchViewModel
{
    [Required]
    public string SearchQuery { get; set; }
}