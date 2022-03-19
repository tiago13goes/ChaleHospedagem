using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Hospedagem_Servico
    {
        //PK, FK
        public int codHospedagem { get; set; }
        //PK
        public DateTime dataServico { get; set; }
        //PK, FK
        public int codServico { get; set; }
    }
}
