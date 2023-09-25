namespace HeroGallery.Services;

public class EmailService : IEmailService
{
	public readonly IEmailSender emailSender;

	public EmailService(IEmailSender emailSender)
	{	
		this.emailSender = emailSender;
	}

	public async Task SendEmailConfirmationLink(string userName, string email, string? confirmationLink)
	{
		var subject = "Confirming Your Email Address";

		var message = 
			$"<html style=\"padding: 20px;\">" +
			$"<body style=\"font-family: Arial, sans-serif;\">" +
			$"<p>Dear {userName},</p>" +
			$"<p>Thank you for signing up for our service! To complete the registration process, we need to verify your email address.</p>" +
			$"<p>Please click the link below to confirm your email:</p>" +
			$"<p><a href=\"{confirmationLink}\">{confirmationLink}</a></p>" +
			$"<p>If you did not sign up for this service, please ignore this email.</p>" +
			$"<p>Thank you,</p>" +
			$"</body>" +
			$"</html>";

		await emailSender.SendEmailAsync(email, subject, message);
	}

	public async Task SendResetPasswordLink(string userName, string email, string? resetPasswordLink)
	{

		var subject = "Reset Password Link";

		var message =
					$"<html style=\"padding: 20px;\">" +
					$"<body style=\"font-family: Arial, sans-serif;\">" +
					$"<h5>We received a request to reset your password. If you did not make this request, please ignore this email.</h5>" +
					$"<h3>To reset your password, please click the link below:</h3>" +
					$"<a href=\"{resetPasswordLink}\">{resetPasswordLink}</a>" +
					$"<p>This link is only valid for the next 24 hours. If you do not reset your password within this time, " +
					$"you will need to request another password reset.</p>" +
					$"<p>If you have any questions or concerns, please contact our support team.</p>" +
					$"<p>Thank you,</p>" +
					$"</body>" +
					$"</html>";

		await emailSender.SendEmailAsync(email, subject, message);
	}
}
