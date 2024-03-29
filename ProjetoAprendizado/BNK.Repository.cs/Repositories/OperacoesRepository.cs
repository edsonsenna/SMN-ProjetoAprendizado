﻿using BNK.Domain.Contas;
using BNK.Domain.Operacoes;
using BNK.Infra.Data.Infra;
using System;

namespace BNK.Repository.cs.Repositories
{
    public class OperacoesRepository : DatabaseConnection, IOperacoesRepository
    {
        public enum Procedures
        {
            BNK_InsOperacao,
            BNK_AttOperacao,
           
        }
        public void Deposita(OperacaoDto operacao)
        {
            bool ins_op = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_InsOperacao.ToString());
            AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
            AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
            AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);

            ins_op = ExecuteNonQueryWithReturn() == 0 ? true : ins_op;


            if (ins_op)
            {
                ExecuteProcedure(Procedures.BNK_AttOperacao.ToString());
                AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
                AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
                AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);
                ExecuteNoReturn();
            }
        }

        public void Estorna(OperacaoDto operacao)
        {
            throw new NotImplementedException();
        }

        public void Saque(OperacaoDto operacao)
        {
            bool ins_op = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_InsOperacao.ToString());
            AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
            AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
            AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);

            ins_op = ExecuteNonQueryWithReturn() == 0 ? true : ins_op;


            if (ins_op)
            {
                ExecuteProcedure(Procedures.BNK_AttOperacao.ToString());
                AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
                AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
                AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);
                ExecuteNoReturn();
            }
        }

        public void Transfere(OperacaoDto operacao)
        {
            bool ins_op = false;

            Connect();
            ExecuteProcedure(Procedures.BNK_InsOperacao.ToString());
            AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
            AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
            AddParameter("@Num_SeqlContaDestino", operacao.Num_SeqlContaDestino);
            AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);

            ins_op = ExecuteNonQueryWithReturn() == 0 ? true : ins_op;


            if (ins_op)
            {
                ExecuteProcedure(Procedures.BNK_AttOperacao.ToString());
                AddParameter("@Cod_TipoOperacao", operacao.Cod_TipoOperacao);
                AddParameter("@Num_SeqlContaOrigem", operacao.Num_SeqlContaOrigem);
                AddParameter("@Num_SeqlContaDestino", operacao.Num_SeqlContaDestino);
                AddParameter("@Num_ValorOperacao", operacao.Num_ValorOperacao);
                ExecuteNoReturn();
            }
        }
    }
}
