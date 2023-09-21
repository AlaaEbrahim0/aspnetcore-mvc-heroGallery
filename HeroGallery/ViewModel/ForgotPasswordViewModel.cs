namespace HeroGallery.ViewModel;

public class ForgotPasswordViewModel
{
	[Required]
	[EmailAddress]
	public string Email { get; set; }

}