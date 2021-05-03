﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Models
{
    public class Modelo
    {
        public int ModeloID { get; set; }
        public string Nome { get; set; }

        public ICollection<Equipamento> Equipamentos { get; set; }

    }
}
