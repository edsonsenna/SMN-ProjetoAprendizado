using BNK.Web.Application.Contas;
using BNK.Web.Application.Operacoes;
using BNK.Web.Application.Usuarios;
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

            container.Register<UsuarioApplication>();

            container.Verify();

            

            return container;
        }
    }
}