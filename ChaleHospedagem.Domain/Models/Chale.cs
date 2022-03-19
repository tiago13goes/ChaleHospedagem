using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Models
{
    public class Chale
    {
        //[Key]
        public int codChale { get; set; }
        public int localizacao { get; set; }
        public int capacidade { get; set; }
        public int valorAltaEstacao { get; set; }
        public int valorBaixaEstacao { get; set; }
    }
}
