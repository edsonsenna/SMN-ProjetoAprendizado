
using System;

namespace BNK.Domain.Contas
{
    public class ContaDto
    {
        public int Num_SeqlConta { get; set; }
        public string Nom_ClienteConta { get; set; }
        public decimal Num_SaldoConta { get; set; }
        public int Cod_TipoConta { get; set; }
        public DateTime Date_DataOperacao { get; set; }
    }
}
