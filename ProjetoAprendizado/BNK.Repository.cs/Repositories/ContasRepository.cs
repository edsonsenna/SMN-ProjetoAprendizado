using BNK.Domain.Contas;
using BNK.Domain.Operacoes;
using BNK.Infra.Data.Infra;
using System;
using System.Collections.Generic;

namespace BNK.Repository.Repositories
{
    public class ContasRepository : DatabaseConnection, IContasRepository
    {
       

        public ContasRepository()
        {

        }

        public enum Procedures
        {
            BNK_SelOperacoesCliente
        }

        public void Deposita(decimal valor)
        {
            

           

        }

        public void Estorna(int codOperacao)
        {
            throw new NotImplementedException();
        }

        public void Saque(decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Transfere(decimal valor, int contaDestino)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperacaoModal> Operacoes(int conta)
        {
            Connect();
            ExecuteProcedure(Procedures.BNK_SelOperacoesCliente.ToString());
            AddParameter("@Num_SeqlConta", 1);

            var operacoes = new List<OperacaoModal>();

            using (var leitor = ExecuteReader())
            {
  
                while (leitor.Read())
                {
                   
                    operacoes.Add(new OperacaoModal
                    {
                        Num_SeqlOperacao = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlOperacao")),
                        Num_SeqlContaOrigem = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaOrigem")),
                        Num_SeqlContaDestino = leitor.IsDBNull(leitor.GetOrdinal("Num_SeqlContaDestino")) ? 0 : 
                                                leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaDestino")),
                        Num_ValorOperacao = leitor.GetDecimal(leitor.GetOrdinal("Num_ValorOperacao")),
                        Cod_TipoOperacao = leitor.GetByte(leitor.GetOrdinal("Cod_TipoOperacao")),
                        Date_DataOperacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataOperacao"))
                    });
                    
                       
                }
                
               
            }
                
                    

            return operacoes;
        }
    }
}
