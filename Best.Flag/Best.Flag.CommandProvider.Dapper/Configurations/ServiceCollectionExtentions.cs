using Best.Flag.CommandProvider.Dapper.Handlers;
using Best.Practices.Core.CommandProvider.Dapper.UnitOfWork;
using Best.Practices.Core.UnitOfWork.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

namespace Best.Flag.CommandProvider.Dapper.Configurations
{
    public static class ServiceCollectionExtentions
    {
        public static void MapUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, DapperUnitOfWork>();
        }

        public static void MapConnection(this IServiceCollection service, IConfigurationSection section)
        {
            var connectionString =
               "Server=" + section["DatabaseServerName"] +
               ";Database=" + section["DatabaseName"] +
               ";Uid=" + section["DatabaseUser"] +
               ";Pwd=" + section["DatabasePassWord"] + ";";

            var connection = new MySqlConnection(connectionString);

            service.AddScoped(c => connection);
            service.AddScoped<IDbConnection, MySqlConnection>(c => connection);
            SqlMapper.AddTypeHandler(new MySqlGuidTypeHandler());
        }

        public static void MapCommandProviders(this IServiceCollection service)
        {
        }

        public static void MapRepositories(this IServiceCollection service)
        {
        }
    }
}