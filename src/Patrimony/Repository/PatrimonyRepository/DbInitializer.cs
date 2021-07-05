using SGP.Model.Entity;
using System.Linq;


namespace SGP.Patrimony.Repository.PatrimonyRepository
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

            var itemCategories = new CategoriaDoItem[]
            {
                new CategoriaDoItem{Nome = "Computador"},
                new CategoriaDoItem{Nome = "Impressora"}
            };

            foreach (CategoriaDoItem itemCategory in itemCategories)
            {
                context.Categoria.Add(itemCategory);
            }
            context.SaveChanges();

            var assetClassifications = new ClassificacaoDeAtivos[]
            {
                new ClassificacaoDeAtivos{Nome = "Informática e Comunicação", TaxaDeDepreciacao = 20, VidaUtil = 5},
                new ClassificacaoDeAtivos{Nome = "Móveis e utensílios", TaxaDeDepreciacao = 10, VidaUtil = 10},
                new ClassificacaoDeAtivos{Nome = "Imoveis", TaxaDeDepreciacao = 4, VidaUtil = 25},
                new ClassificacaoDeAtivos{Nome = "Instalaçoes", TaxaDeDepreciacao = 10, VidaUtil = 10},
                new ClassificacaoDeAtivos{Nome = "Veiculos leves", TaxaDeDepreciacao = 20, VidaUtil = 5},
                new ClassificacaoDeAtivos{Nome = "Veiculos pesados", TaxaDeDepreciacao = 25, VidaUtil = 4},

            };
            foreach (ClassificacaoDeAtivos assetClassification in assetClassifications)
            {
                context.Classificacao.Add(assetClassification);
            }
            context.SaveChanges();

            var equipmentModels = new ModeloDeEquipamento[]
            {
                new ModeloDeEquipamento{Nome = "Vostro"},
                new ModeloDeEquipamento{Nome = "Ispiron 3647"}
            };
            foreach(ModeloDeEquipamento equipmentModel in equipmentModels)
            {
                context.ModeloDeEquipamento.Add(equipmentModel);
            }
            context.SaveChanges();

            var manufacturers = new Fabricante[]
            {
                new Fabricante{Nome = "Sena Corp", Cnpj ="06414576506", Cep = 40270440, Endereco ="Travessa Portugal, 23", Cidade = "Salvador", UF = "BA", Telefone ="71992257224", Email = "eriksena16@gmail.com"},
                new Fabricante{Nome = "Culinaria Brandão", Cnpj ="72629878520", Cep = 40270440, Endereco ="Rua cirilo Barbosa, 34", Cidade = "Salvador", UF = "BA", Telefone ="7188516589", Email = "culinaria@gmail.com"}
            };
            foreach (Fabricante manufacturer in manufacturers)
            {
                context.Fabricante.Add(manufacturer);
            }
            context.SaveChanges();

            var sectors = new Setor[]
            {
                new Setor{Nome ="T.I"},
                new Setor{Nome ="RH"}
            };
            foreach (Setor s in sectors)
            {
                context.Setor.Add(s);
            }
            context.SaveChanges();

            var responsaveis = new ResponsavelDoEquipamento[]
            {
                new ResponsavelDoEquipamento{Nome = "Erik", Sobrenome = "Sena"}
            };
            foreach (ResponsavelDoEquipamento equipmentPerson in responsaveis)
            {
                context.ResponsavelDoEquipamento.Add(equipmentPerson);
            }
            context.SaveChanges();

           

        }


    }
}
