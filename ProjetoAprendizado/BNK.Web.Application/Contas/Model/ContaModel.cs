using System;

namespace BNK.Web.Application.Contas.Model
{
    public class ContaModel
    {
        public int Num_SeqlConta { get; set; }
        public string Nom_ClienteConta { get; set; }
        public decimal Num_SaldoConta { get; set; }
        public int Cod_TipoConta { get; set; }
        public DateTime Date_DataCriacao { get; set; }
    }
}
