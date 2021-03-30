﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models.Categorias
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nome { get; set; }
        public ICollection<Equipamentos.Equipamento> Equipamentos { get; set; }
    }
}
