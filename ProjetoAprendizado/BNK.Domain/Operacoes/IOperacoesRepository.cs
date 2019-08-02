using BNK.Domain.Operacoes;

namespace BNK.Domain.Contas
{
    public interface IOperacoesRepository
    {
        void Deposita(OperacaoModal operacao);
        void Saque(decimal valor);
        void Transfere(decimal valor, int contaDestino);
        void Estorna(int codOperacao);
    }
}
