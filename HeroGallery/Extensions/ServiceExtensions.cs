namespace HeroGallery.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
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
    public static void ConfigureAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("DeleteRolePolicy",
                policy => policy
                    .RequireClaim("Delete Role", "true"));

            options.AddPolicy("AdminRolePolicy",
                policy => policy.RequireRole("Admin"));

            options.AddPolicy("EditRolePolicy",
                policy => policy
                    .RequireClaim("Edit Role", "true"));

        });
    }
    public static void ConfigureIdentity(this IServiceCollection services)
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

    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration _config)
    {
        services.AddAuthentication()
          .AddGoogle(options =>
          {
              options.ClientId = _config["ClientId"];
              options.ClientSecret = _config["ClientSecret"];
          });


    }
    public static void ConfigureMvc(this IServiceCollection services, IConfiguration _config)
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
