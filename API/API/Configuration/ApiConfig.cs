using AutoMapper;
using API.AutoMapper;
using API.Dtos;
using API.Interfaces.Repositories.Crud;
using API.Interfaces.Services.Crud;
using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection ApiConfiServices(this IServiceCollection services)
        {
            #region Repositorios 
            services.AddScoped<ICrudRepositorio<Tarefa>, TarefaRepositorio>();
            #endregion Repositorios 

            #region Services
            services.AddScoped<ICrudService<Tarefa, TarefaDto>, TarefaService>();
            #endregion Services 

            #region AutoMapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiMapper());
            });            

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion AutoMapper

            return services;
        }
    }
}
