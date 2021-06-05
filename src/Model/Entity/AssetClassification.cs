﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGP.Model.Entity
{
    public class AssetClassification
    {
        public int ClassificacaoID { get; set; }
        public string Nome { get; set; }
        [Display(Name ="Taxa de depreciação")]
        public int Taxa { get; set; }
        [Display(Name ="Vida Útil")]
        public int VidaUtil { get; set; }

        public ICollection<Equipment> Equipamentos { get; set; }
    }
}
