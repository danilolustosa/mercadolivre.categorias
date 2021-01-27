using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLivreCategorias.Entity
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int? IdPai { get; set; }
        public int Nivel { get; set; }
        public string Json { get; set; }
    }
}
