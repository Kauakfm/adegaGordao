using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Application.Model
{
    public class Produto
    {
        public int numeroProduto { get; set; }

        public string nome { get; set; }

        public decimal valor { get; set; }

        public int ml { get; set; }
            
        public int tipo { get; set; }

        public string? Foto { get; set; }


    }
}
