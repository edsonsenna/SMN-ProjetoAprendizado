
using System;

namespace BNK.Web.Application.Operacoes.Model
{
    public class OperacaoModal
    {
        public int Num_SeqlOperacao { get; set; }
        public byte Cod_TipoOperacao { get; set; }
        public int Num_SeqlContaOrigem { get; set; }
        public int? Num_SeqlContaDestino { get; set; }
        public decimal Num_ValorOperacao { get; set; }
        public DateTime Date_DataOperacao { get; set; } 
    }
}
