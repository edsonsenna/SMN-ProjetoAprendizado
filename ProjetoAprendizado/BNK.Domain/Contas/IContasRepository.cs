using BNK.Domain.Operacoes;
using System.Collections.Generic;

namespace BNK.Domain.Contas
{
    public interface IContasRepository
    {
        IEnumerable<OperacaoDto> Operacoes(int conta);

    }
}
