using AutoMapper;
using SGP.Model.Entity;
using SGP.Model.Entity.DTO;

namespace SGP.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<CategoriaDoItem, CategoriaDoItemViewModel>().ReverseMap();

            CreateMap<Equipamento, EquipamentoViewModel>().ReverseMap();

        }
    }
}
