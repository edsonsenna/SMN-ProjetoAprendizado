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
            BNK_SelInfoCliente,
            BNK_AttConta
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
                    Num_SaldoConta = leitor.GetDecimal(leitor.GetOrdinal("Num_SaldoConta")),
                    Date_DataCriacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataCriacao")),
                    Nom_TipoConta = leitor.GetString(leitor.GetOrdinal("Nom_TipoConta")),
                    Nom_NomeUsuar = leitor.GetString(leitor.GetOrdinal("Nom_NomeUsuar"))
                };

             
            }

            return conta;
        }

        public ContaDto AttConta(ContaDto conta)
        {

            bool ins_op = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_AttConta.ToString());
            AddParameter("@Num_SeqlConta", conta.Num_SeqlConta);
            AddParameter("@Cod_TipoConta", conta.Cod_TipoConta);

            ins_op = ExecuteNonQueryWithReturn() == 0 ? true : ins_op;

            if (ins_op)
            {
                Connect();
                ExecuteProcedure(Procedures.BNK_SelInfoCliente.ToString());
                AddParameter("@Num_SeqlConta", conta.Num_SeqlConta);

                ContaDto conta_Att = new ContaDto();

                using (var leitor = ExecuteReader())
                {
                    leitor.Read();

                    conta_Att = new ContaDto()
                    {
                        Num_SeqlConta = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlConta")),
                        Cod_TipoConta = leitor.GetByte(leitor.GetOrdinal("Cod_TipoConta")),
                        Nom_NomeUsuar = leitor.GetString(leitor.GetOrdinal("Nom_NomeUsuar")),
                        Num_SaldoConta = leitor.GetDecimal(leitor.GetOrdinal("Num_SaldoConta")),
                        Date_DataCriacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataCriacao")),
                        Nom_TipoConta = leitor.GetString(leitor.GetOrdinal("Nom_TipoConta"))
                    };


                }

                return conta_Att;
           
            }

            return null;


        }
    }
}
