namespace HeroGallery.ViewModel;

public class HeroEditViewModel : HeroCreateViewModel
{
    public int Id { get; set; }
    public string ExistingPhotoPath { get; set; }
}
