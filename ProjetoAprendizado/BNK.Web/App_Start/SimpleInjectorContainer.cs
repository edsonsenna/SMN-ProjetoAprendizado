using BNK.Web.Application.Contas;
using BNK.Web.Application.Operacoes;
using SimpleInjector;

namespace BNK.Web.App_Start
{
    public class SimpleInjectorContainer
    {

        public static Container Build()
        {
            var container = new Container();


            container.Register<OperacaoApplication>();

            container.Register<ContaApplication>();

            container.Verify();

            

            return container;
        }
    }
}