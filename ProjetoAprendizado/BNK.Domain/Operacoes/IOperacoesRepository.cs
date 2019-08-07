using BNK.Domain.Operacoes;

namespace BNK.Domain.Contas
{
    public interface IOperacoesRepository
    {
        void Deposita(OperacaoDto operacao);
        void Saque(OperacaoDto operacao);
        void Transfere(OperacaoDto operacao);
        void Estorna(OperacaoDto operacao);
    }
}
