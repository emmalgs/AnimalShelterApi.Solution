using Microsoft.AspNetCore.Mvc.Versioning;

namespace AnimalShelterApi.Startup;

public static class DependencyInjectionSetup
{
  public static IServiceCollection RegisterServices(this IServiceCollection services)
  {
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
    services.AddAuthentication();

    services.AddApiVersioning(opt =>
                                    {
                                      opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                                      opt.AssumeDefaultVersionWhenUnspecified = true;
                                      opt.ReportApiVersions = true;
                                      opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                      new HeaderApiVersionReader("x-api-version"),
                                                                                      new MediaTypeApiVersionReader("x-api-version"));
                                    });

    services.AddVersionedApiExplorer(setup =>
                                      {
                                          setup.GroupNameFormat = "'v'VVV";
                                          setup.SubstituteApiVersionInUrl = true;
                                      });

    services.ConfigureOptions<SwaggerConfiguration.ConfigureSwaggerOptions>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    return services;
  }
}