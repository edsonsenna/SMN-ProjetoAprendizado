using BNK.Domain.Operacoes;
using System.Collections.Generic;

namespace BNK.Domain.Contas
{
    public interface IContasRepository
    {
        void Deposita(decimal valor);
        void Saque(decimal valor);
        void Transfere(decimal valor, int contaDestino);
        void Estorna(int codOperacao);
        IEnumerable<OperacaoModal> Operacoes(int conta);

    }
}
