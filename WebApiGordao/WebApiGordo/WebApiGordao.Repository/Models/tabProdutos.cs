using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiGordao.Repository.Models
{
    public class tabProdutos
    {
        public int id { get; set; }

        public string nomeProduto { get; set; }
        
        public decimal valor { get; set; }

        public int quantidadeMl { get; set; }

        public int tipoId { get; set; }

        public string? Foto { get; set; }
    }
}
