﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGP.Models.Equipamentos;
using SGP.Models.Setores;
using SGP.Models.Categorias;
using SGP.Models.Classificacoes;
using SGP.Models.Marcas;
using SGP.Models.Responsaveis;
using SGP.Models.Modelos;

namespace SGP.Data
{
    public class DbInitializer
    {
        public static void Initialize(SGPContext context)
        {
            context.Database.EnsureCreated();

            if (context.Categoria.Any())
            {
                return;
            }

            var categorias = new Categoria[]
            {
                new Categoria{Nome = "Computador"},
                new Categoria{Nome = "Impressora"}
            };

            foreach (Categoria c in categorias)
            {
                context.Categoria.Add(c);
            }
            context.SaveChanges();

            var classificacao = new Classificacao[]
            {
                new Classificacao{Nome = "Informática e Comunicação", taxa = 20, VidaUtil = 5},
                new Classificacao{Nome = "Móveis e utensílios", taxa = 10, VidaUtil = 10},
                new Classificacao{Nome = "Imoveis", taxa = 4, VidaUtil = 25},
                new Classificacao{Nome = "Instalaçoes", taxa = 10, VidaUtil = 10},
                new Classificacao{Nome = "Veiculos leves", taxa = 20, VidaUtil = 5},
                new Classificacao{Nome = "Veiculos pesados", taxa = 25, VidaUtil = 4},

            };
            foreach (Classificacao cl in classificacao)
            {
                context.Classificacao.Add(cl);
            }
            context.SaveChanges();

            var modelos = new Modelo[]
            {
                new Modelo{Nome = "Vostro"},
                new Modelo{Nome = "Ispiron 3647"}
            };
            foreach(Modelo m in modelos)
            {
                context.Modelo.Add(m);
            }
            context.SaveChanges();
            var marcas = new Marca[]
            {
                new Marca{Nome = "Sena Corp", Cnpj ="06414576506", Endereco ="Travessa Portugal, 23", Telefone ="71992257224"},
                new Marca{Nome = "Culinaria Brandão", Cnpj = "72629878520", Endereco ="Rua cirilo Barbosa, 34", Telefone = "7188516589"}
            };
            foreach (Marca m in marcas)
            {
                context.Marcas.Add(m);
            }
            context.SaveChanges();

            var setores = new Setor[]
            {
                new Setor{Nome ="T.I"},
                new Setor{Nome ="RH"}
            };
            foreach (Setor s in setores)
            {
                context.Setor.Add(s);
            }
            context.SaveChanges();

            var responsaveis = new Responsavel[]
            {
                new Responsavel{Nome = "Erik Sena"}
            };
            foreach (Responsavel r in responsaveis)
            {
                context.Responsavel.Add(r);
            }
            context.SaveChanges();

           

        }


    }
}