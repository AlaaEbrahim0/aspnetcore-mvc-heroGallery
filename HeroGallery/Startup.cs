using HeroGallery.Services;

namespace HeroGallery;

public class Startup
{
    private IConfiguration _config;


    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {

        services.ConfigureMvc(_config);
        services.ConfigureMvc(_config);
        services.ConfigureIdentity();
        services.ConfigureAuthentication(_config);
        services.ConfigureAuthorization();

        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailService, EmailService>();
        services.AddScoped<IHeroRepository, SqlHeroRepository>();

        services.AddDbContextPool<AppDbContext>(
            options => options.UseSqlServer(_config.GetConnectionString("HeroDbProdConnection")));

        services.ConfigureApplicationCookie(options =>
            options.AccessDeniedPath = new PathString("/Adminstration/AccessDenied"));

        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromHours(5);
        });


    }

    // This method gets called by the runtime. Use this method to configure the HTTP reqsuest pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        else
            app.UseHsts();

        app.UseExceptionHandler("/Error");

        app.UseStatusCodePagesWithReExecute("/Error/{0}");

        app.UseStaticFiles();

        app.UseCors("CorsPolicy");

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseMvcWithDefaultRoute();

    }
}
