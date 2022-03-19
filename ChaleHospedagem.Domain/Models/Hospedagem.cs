using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Hospedagem
    {
        //[Key]
        public int codHospedagem { get; set; }
        //FK
        public int codChale { get; set; }
        public string estado { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int qtdPessoas { get; set; }
        public double desconto { get; set; }
        public double valorFinal { get; set; }

    }
}
