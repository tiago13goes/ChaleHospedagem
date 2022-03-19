using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Cliente
    {
        //PK
        //[Key]
        public int codCliente { get; set; }
        public string rgCliente { get; set; }
        public string enderecoCliente { get; set; }
        public string bairroCliente { get; set; }
        public string cidadeCliente { get; set; }
        public string estadoCliente { get; set; }
        public string CEPCliente { get; set; }
        public DateTime nascimentoCliente { get; set; }
    }
}
