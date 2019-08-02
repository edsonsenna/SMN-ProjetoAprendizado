﻿using BNK.Domain.Contas;
using BNK.Infra.Data.Infra;
using BNK.Repository.Repositories;
using SimpleInjector;
using System.Web.Http;

namespace Api.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterServices()
        {
            var container = new Container();

            container.Register<IDatabaseConnection, DatabaseConnection>();
            container.Register<IContasRepository, ContasRepository>();


            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            

            container.Verify();

            return container;
        }
    }
}