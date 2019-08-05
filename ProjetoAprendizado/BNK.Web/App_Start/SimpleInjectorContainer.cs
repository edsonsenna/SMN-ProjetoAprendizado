using BNK.Web.Application.Operacoes;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

namespace BNK.Web.App_Start
{
    public class SimpleInjectorContainer
    {

        public static Container Build()
        {
            var container = new Container();


            container.Register<OperacaoApplication>();

            container.Verify();

            

            return container;
        }
    }
}