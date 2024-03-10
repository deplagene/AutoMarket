namespace AutoMarketProject.WebApi.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}