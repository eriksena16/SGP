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

            var manufacturers = new Fabricante[]
            {
                new Fabricante{Nome = "Sena Corp", Cnpj ="06941212406", Cep = 40270440, Endereco ="Travessa Amazonas", Cidade = "Salvador", UF = "BA", Telefone ="71992257224", Email = "eriksena16@gmail.com"},
                new Fabricante{Nome = "Culinaria Brandão", Cnpj ="72669852420", Cep = 40270870, Endereco ="Rua Salvador", Cidade = "Salvador", UF = "BA", Telefone ="718898789", Email = "culinaria@gmail.com"}
            };
            foreach (Fabricante manufacturer in manufacturers)
            {
                context.Fabricante.Add(manufacturer);
            }
            context.SaveChanges();

            var EquipmentooModels = new ModeloDeEquipamento[]
            {
                new ModeloDeEquipamento{FabricanteId = 1, Nome = "Vostro"},
                new ModeloDeEquipamento{FabricanteId = 1, Nome = "Ispiron 3647"}
            };
            foreach(ModeloDeEquipamento EquipmentooModel in EquipmentooModels)
            {
                context.ModeloDeEquipamento.Add(EquipmentooModel);
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

            var responsaveis = new ResponsavelDoEquipamento[]
            {
                new ResponsavelDoEquipamento{Nome = "Erik", Sobrenome = "Sena"}
            };
            foreach (ResponsavelDoEquipamento EquipmentooPerson in responsaveis)
            {
                context.ResponsavelDoEquipamento.Add(EquipmentooPerson);
            }
            context.SaveChanges();

           

        }


    }
}
