using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Telefone
    {
        //PK
        //[Key]
        public string telefone { get; set; }
        //PK, FK
        public int codCliente { get; set; }
    }
}
