namespace BNK.Domain.Contas
{
    public interface IOperacoesRepository
    {
        void Deposita(decimal valor);
        void Saque(decimal valor);
        void Transfere(decimal valor, int contaDestino);
        void Estorna(int codOperacao);
    }
}
