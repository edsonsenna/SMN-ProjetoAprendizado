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
            BNK_InsOperacao,
            BNK_AttOperacao,
            BNK_SelOperacoesCliente
        }

        public void Deposita(decimal valor)
        {
            bool ins_op = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_InsOperacao.ToString());
            AddParameter("@Cod_TipoOperacao", 2);
            AddParameter("@Num_SeqlContaOrigem", 1);
            AddParameter("@Num_ValorOperacao", valor);

            ins_op = ExecuteNonQueryWithReturn() == 0 ? true : ins_op;
                    

            if (ins_op)
            {
                ExecuteProcedure(Procedures.BNK_AttOperacao.ToString());
                AddParameter("@Cod_TipoOperacao", 2);
                AddParameter("@Num_SeqlContaOrigem", 1);
                AddParameter("@Num_ValorOperacao", valor);
                ExecuteNoReturn();
            }

           

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

        public IEnumerable<OperacaoDto> Operacoes(int conta)
        {
            Connect();
            ExecuteProcedure(Procedures.BNK_SelOperacoesCliente.ToString());
            AddParameter("@Num_SeqlConta", 1);

            var operacoes = new List<OperacaoDto>();

            using (var leitor = ExecuteReader())
            {
                while (leitor.HasRows)
                {
                    while (leitor.Read())
                    {
                        operacoes.Add(new OperacaoDto
                        {
                            Num_SeqlOperacao = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlOperacao")),
                            Num_SeqlContaOrigem = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaOrigem")),
                            Num_SeqlContaDestino = leitor.GetInt32(leitor.GetOrdinal("Num_SeqlContaDestino")),
                            Num_ValorOperacao = leitor.GetDecimal(leitor.GetOrdinal("Num_ValorOperacao")),
                            Cod_TipoOperacao = leitor.GetByte(leitor.GetOrdinal("Num_SeqlContaOrigem")),
                            Date_DataOperacao = leitor.GetDateTime(leitor.GetOrdinal("Date_DataOperacao"))
                        });
                    }
                    leitor.NextResult();
                }
               
            }
                
                    

            return operacoes;
        }
    }
}
