using BNK.Domain.Contas;
using BNK.Domain.Usuarios;
using BNK.Domain.Usuarios.Dto;
using BNK.Infra.Data.Infra;
using System.Collections.Generic;

namespace BNK.Repository.cs.Repositories
{
    public class UsuariosRepository : DatabaseConnection, IUsuariosRepository
    {
        public enum Procedures
        {
            BNK_VerAcesso,
            BNK_SelContasCli
        }

        public List<ContaDto> Acesso(UsuarioDto usuario)
        {
            List<ContaDto> contas = new List<ContaDto>();
            UsuarioDto usuario_log = new UsuarioDto();

            bool hasRow = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_VerAcesso.ToString());
            AddParameter("@Nom_NomeUsuar", usuario.Nom_NomeUsuar);
            AddParameter("@Nom_SenhaUsuar", usuario.Nom_SenhaUsuar);

            using (var leitor = ExecuteReader())
            {
                leitor.Read();

                if (leitor.HasRows)
                {
                    usuario_log = new UsuarioDto()
                    {
                        Num_SeqlUsuar = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlUsuar")),
                        Nom_NomeUsuar = leitor.GetString(leitor.GetOrdinal("Nom_NomeUsuar")),
                        Nom_SenhaUsuar = leitor.GetString(leitor.GetOrdinal("Nom_SenhaUsuar"))
                    };
                }

               
                hasRow = leitor.HasRows;

            }

            if (hasRow)
            {
                Connect();
                ExecuteProcedure(Procedures.BNK_SelContasCli.ToString());
                AddParameter("@Num_SeqlUsuar", usuario_log.Num_SeqlUsuar);
                

                using (var leitor = ExecuteReader())
                {

                    while (leitor.Read())
                    {

                        contas.Add(new ContaDto
                        {
                            Num_SeqlConta = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlConta")),
                            Cod_TipoConta = leitor.GetByte(leitor.GetOrdinal("Cod_TipoConta")),
                            Num_SeqlUsuar = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlUsuar")),
                            Num_SaldoConta = leitor.GetDecimal(leitor.GetOrdinal("Num_SaldoConta")),
                            Date_DataCriacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataCriacao")),
                            Nom_TipoConta = leitor.GetString(leitor.GetOrdinal("Nom_TipoConta")),
                            Nom_NomeUsuar = leitor.GetString(leitor.GetOrdinal("Nom_NomeUsuar"))
                            

                        });
                    
                    }


                }

                return contas;
            }

            return null;


            
        }
    }
}
