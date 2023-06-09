using AnimalShelterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<TravelApiContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                      builder.Configuration["ConnectionStrings:DefaultConnection"],
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<TravelApiContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(opt =>
                                    {
                                      opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                                      opt.AssumeDefaultVersionWhenUnspecified = true;
                                      opt.ReportApiVersions = true;
                                      opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                      new HeaderApiVersionReader("x-api-version"),
                                                                                      new MediaTypeApiVersionReader("x-api-version"));
                                    });

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options => 
  {
    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
  });
}
else
{
  app.UseHttpsRedirection();
}
app.UseStaticFiles();
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();


public class ConfigureSwaggerOptions
    : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        _provider = provider;
    }
    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
    private OpenApiInfo CreateVersionInfo(
            ApiVersionDescription desc)
    {
        var info = new OpenApiInfo()
        {
            Title = ".NET Core (.NET 6) Web API",
            Version = desc.ApiVersion.ToString()
        };

        if (desc.IsDeprecated)
        {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }

        return info;
    }
}