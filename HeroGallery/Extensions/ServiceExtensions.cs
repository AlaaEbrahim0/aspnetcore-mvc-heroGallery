	namespace HeroGallery.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(IServiceCollection services)
	{
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			{
				builder
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowAnyOrigin();
			});

		});
	}
	public static void ConfigureAuthorization(IServiceCollection services)
	{
		services.AddAuthorization(options =>
		{
			options.AddPolicy("DeleteRolePolicy",
				policy => policy.RequireClaim("Delete Role", "true"));


			options.AddPolicy("AdminRolePolicy",
				policy => policy.RequireRole("Admin"));

		});
	}
	public static void ConfigureIdentity(IServiceCollection services)
	{
		services.AddIdentity<ApplicationUser, IdentityRole>(options =>
		{
			options.Password.RequiredLength = 10;
			options.Password.RequiredUniqueChars = 3;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.SignIn.RequireConfirmedEmail = true;
		})
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();
	}
	public static void ConfigureAuthentication(IServiceCollection services, IConfiguration _config)
	{
		services.AddAuthentication()
		  .AddGoogle(options =>
		  {
			  options.ClientId = _config["GoogleClientId"];
			  options.ClientSecret = _config["GoogleClientSecret"];
		  });
		services.AddDbContextPool<AppDbContext>(
			options => options.UseSqlServer(_config.GetConnectionString("HeroDbConnection")));
				
	}
	public static void ConfigureMvc(IServiceCollection services, IConfiguration _config)
	{
		services.AddMvc(options =>
		{
			options.EnableEndpointRouting = false;

			var policy = new AuthorizationPolicyBuilder()
							.RequireAuthenticatedUser()
							.Build();

			options.Filters.Add(new AuthorizeFilter(policy));

		});
	}
}
