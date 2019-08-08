using BNK.Domain.Usuarios;
using BNK.Domain.Usuarios.Dto;
using BNK.Infra.Data.Infra;

namespace BNK.Repository.cs.Repositories
{
    public class UsuariosRepository : DatabaseConnection, IUsuariosRepository
    {
        public enum Procedures
        {
            BNK_VerAcesso
        }

        public int Acesso(UsuarioDto usuario)
        {
            bool hasRow = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_VerAcesso.ToString());
            AddParameter("@Nom_NomeUsuar", usuario.Nom_NomeUsuar);
            AddParameter("@Nom_SenhaUsuar", usuario.Nom_SenhaUsuar);

            using (var leitor = ExecuteReader())
            {
                leitor.Read();

                hasRow = leitor.HasRows;

            }

            

            return hasRow ? 0 : 1;
            
        }
    }
}
