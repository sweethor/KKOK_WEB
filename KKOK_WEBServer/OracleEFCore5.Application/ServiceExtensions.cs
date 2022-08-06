using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OracleEFCore5.Application.Behaviours;
using OracleEFCore5.Application.Helpers;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Reflection;

namespace OracleEFCore5.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IDataShapeHelper<TestTable>, DataShapeHelper<TestTable>>();
            services.AddScoped<IDataShapeHelper<Member>, DataShapeHelper<Member>>();
            services.AddScoped<IDataShapeHelper<Pjt_Member>, DataShapeHelper<Pjt_Member>>();
            services.AddScoped<IModelHelper, ModelHelper>();
            //services.AddScoped<IMockData, MockData>();
        }
    }
}
