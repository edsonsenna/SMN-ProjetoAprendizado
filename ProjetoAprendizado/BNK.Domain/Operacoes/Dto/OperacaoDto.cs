
using System;

namespace BNK.Domain.Operacoes
{
    public class OperacaoDto
    {
        public int Num_SeqlOperacao { get; set; }
        public byte Cod_TipoOperacao { get; set; }
        public string Nom_TipoOperacao { get; set; }
        public int Num_SeqlContaOrigem { get; set; }
        public int? Num_SeqlContaDestino { get; set; }
        public decimal Num_ValorOperacao { get; set; }
        public DateTime Date_DataOperacao { get; set; } 
    }
}
