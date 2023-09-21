namespace HeroGallery.ViewModel;

	public class UserClaimsViewModel
	{
    public string UserId { get; set; }
    public List<UserClaim> Claims { get; set; } = new List<UserClaim>();
}
