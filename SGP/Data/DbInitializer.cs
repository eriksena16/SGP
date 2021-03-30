using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGP.Models.Equipamentos;
using SGP.Models.Setores;
using SGP.Models.Categorias;
using SGP.Models.Classificacoes;
using SGP.Models.Fornecedores;
using SGP.Models.Responsaveis;

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
                new Classificacao{Nome = "Informática e Comunicação", taxa = 20},
                new Classificacao{Nome = "Móveis e utensílios", taxa = 15}

            };
            foreach (Classificacao cl in classificacao)
            {
                context.Classificacao.Add(cl);
            }
            context.SaveChanges();

            var fornecedores = new Fornecedor[]
            {
                new Fornecedor{Nome = "Sena Corp", Cnpj ="06414576506", Endereco ="Travessa Portugal, 23", Telefone ="71992257224"},
                new Fornecedor{Nome = "Culinaria Brandão", Cnpj = "72629878520", Endereco ="Rua cirilo Barbosa, 34", Telefone = "7188516589"}
            };
            foreach (Fornecedor f in fornecedores)
            {
                context.Fornecedores.Add(f);
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

            var equipamentos = new Equipamento[]
            {
                new Equipamento{EquipamentoID =1, CategoriaID=1,ClassificacaoID=2,Nota="402563", ValorDeCompra = 30, DataDeCompra=DateTime.Parse("2020-09-01"),
                    EstadoDeConservacao = EstadoDeConservacao.Bom , Modelo = "Vostro", FornecedorID = 1, Serie = "15355", Status = Status.Ativo, SetorID = 1, ResponsavelID = 1 },
                new Equipamento{EquipamentoID =2, CategoriaID=2,ClassificacaoID=1,Nota="402564", ValorDeCompra = 45, DataDeCompra=DateTime.Parse("2020-04-30"),
                    EstadoDeConservacao = EstadoDeConservacao.Ruim, Modelo = "Ispiron", FornecedorID = 1, Serie = "153554", Status = Status.Inativo, SetorID = 2, ResponsavelID = 2 },
                new Equipamento{EquipamentoID =3, CategoriaID=1,ClassificacaoID=1,Nota="402563", ValorDeCompra = 30, DataDeCompra=DateTime.Parse("2020-09-01"),
                    EstadoDeConservacao = EstadoDeConservacao.Otimo, Modelo = "Vostro", FornecedorID = 1, Serie = "1535547", Status = Status.Ativo, SetorID = 1, ResponsavelID = 1 }
            };
            foreach (Equipamento e in equipamentos)
            {
                context.Equipamentos.Add(e);
            }
            context.SaveChanges();




        }


    }
}
