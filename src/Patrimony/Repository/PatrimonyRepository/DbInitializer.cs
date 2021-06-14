using SGP.Model.Entity;
using System.Linq;


namespace SGP.Patrimony.Repository.PatrimonyRepository
{
    public class DbInitializer
    {
        public static void Initialize(SGPContext context)
        {
            context.Database.EnsureCreated();

            if (context.ItemCategory.Any())
            {
                return;
            }

            var itemCategories = new ItemCategory[]
            {
                new ItemCategory{Name = "Computador"},
                new ItemCategory{Name = "Impressora"}
            };

            foreach (ItemCategory itemCategory in itemCategories)
            {
                context.ItemCategory.Add(itemCategory);
            }
            context.SaveChanges();

            var assetClassifications = new AssetClassification[]
            {
                new AssetClassification{Name = "Informática e Comunicação", DepreciationRate = 20, LifeSpan = 5},
                new AssetClassification{Name = "Móveis e utensílios", DepreciationRate = 10, LifeSpan = 10},
                new AssetClassification{Name = "Imoveis", DepreciationRate = 4, LifeSpan = 25},
                new AssetClassification{Name = "Instalaçoes", DepreciationRate = 10, LifeSpan = 10},
                new AssetClassification{Name = "Veiculos leves", DepreciationRate = 20, LifeSpan = 5},
                new AssetClassification{Name = "Veiculos pesados", DepreciationRate = 25, LifeSpan = 4},

            };
            foreach (AssetClassification assetClassification in assetClassifications)
            {
                context.AssetClassification.Add(assetClassification);
            }
            context.SaveChanges();

            var equipmentModels = new EquipmentModel[]
            {
                new EquipmentModel{Name = "Vostro"},
                new EquipmentModel{Name = "Ispiron 3647"}
            };
            foreach(EquipmentModel equipmentModel in equipmentModels)
            {
                context.EquipmentModel.Add(equipmentModel);
            }
            context.SaveChanges();

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer{Name = "Sena Corp", Cnpj ="06414576506", Cep = 40270440, Address ="Travessa Portugal, 23", City = "Salvador", UF = "BA", Phone ="71992257224", Email = "eriksena16@gmail.com"},
                new Manufacturer{Name = "Culinaria Brandão", Cnpj ="72629878520", Cep = 40270440, Address ="Rua cirilo Barbosa, 34", City = "Salvador", UF = "BA", Phone ="7188516589", Email = "culinaria@gmail.com"}
            };
            foreach (Manufacturer manufacturer in manufacturers)
            {
                context.Manufacturer.Add(manufacturer);
            }
            context.SaveChanges();

            var sectors = new Sector[]
            {
                new Sector{Name ="T.I"},
                new Sector{Name ="RH"}
            };
            foreach (Sector s in sectors)
            {
                context.Sector.Add(s);
            }
            context.SaveChanges();

            var responsaveis = new EquipmentPerson[]
            {
                new EquipmentPerson{Name = "Erik", Surname = "Sena"}
            };
            foreach (EquipmentPerson equipmentPerson in responsaveis)
            {
                context.EquipmentPerson.Add(equipmentPerson);
            }
            context.SaveChanges();

           

        }


    }
}
