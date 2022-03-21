using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Servico
    {
        //PK
        //[Key]
        public int codServico { get; set; }
        public string nomeServico { get; set; }
        public double valorServico { get; set; }
    }
}
