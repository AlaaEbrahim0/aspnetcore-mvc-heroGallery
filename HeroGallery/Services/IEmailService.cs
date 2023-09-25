namespace HeroGallery.Services;

public interface IEmailService
{
	public Task SendResetPasswordLink(string userName, string email, string? resetPasswordLink);
	public Task SendEmailConfirmationLink(string userName, string email, string? confirmationLink);
}
