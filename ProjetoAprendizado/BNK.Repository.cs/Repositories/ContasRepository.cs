using BNK.Domain.Contas;
using BNK.Domain.Operacoes;
using BNK.Infra.Data.Infra;
using System.Collections.Generic;

namespace BNK.Repository.Repositories
{
    public class ContasRepository : DatabaseConnection, IContasRepository
    {
       

        
        public enum Procedures
        {
            BNK_SelOperacoesCliente,
            BNK_SelInfoCliente
        }

     
        public IEnumerable<OperacaoDto> Operacoes(int conta)
        {
            Connect();
            ExecuteProcedure(Procedures.BNK_SelOperacoesCliente.ToString());
            AddParameter("@Num_SeqlConta", conta);

            var operacoes = new List<OperacaoDto>();

            using (var leitor = ExecuteReader())
            {
  
                while (leitor.Read())
                {
                   
                    operacoes.Add(new OperacaoDto
                    {
                        Num_SeqlOperacao = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlOperacao")),
                        Num_SeqlContaOrigem = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaOrigem")),
                        Num_SeqlContaDestino = leitor.IsDBNull(leitor.GetOrdinal("Num_SeqlContaDestino")) ? 0 : 
                                                leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaDestino")),
                        Num_ValorOperacao = leitor.GetDecimal(leitor.GetOrdinal("Num_ValorOperacao")),
                        Cod_TipoOperacao = leitor.GetByte(leitor.GetOrdinal("Cod_TipoOperacao")),
                        Nom_TipoOperacao = leitor.GetString(leitor.GetOrdinal("Nom_TipoOperacao")),
                        Date_DataOperacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataOperacao"))
                    });
                    
                       
                }
                
               
            }
                
                    

            return operacoes;
        }

        public ContaDto InfoConta(int Num_SeqlConta)
        {
            Connect();
            ExecuteProcedure(Procedures.BNK_SelInfoCliente.ToString());
            AddParameter("@Num_SeqlConta", Num_SeqlConta);

            ContaDto conta = new ContaDto();

            using (var leitor = ExecuteReader())
            {
                leitor.Read();

                conta = new ContaDto()
                {
                    Num_SeqlConta = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlConta")),
                    Cod_TipoConta = leitor.GetByte(leitor.GetOrdinal("Cod_TipoConta")),
                    Nom_ClienteConta = leitor.GetString(leitor.GetOrdinal("Nom_ClienteConta")),
                    Num_SaldoConta = leitor.GetDecimal(leitor.GetOrdinal("Num_SaldoConta")),
                    Date_DataCriacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataCriacao")),
                    Nom_TipoConta = leitor.GetString(leitor.GetOrdinal("Nom_TipoConta"))
                };

             
            }

            return conta;
        }
    }
}
