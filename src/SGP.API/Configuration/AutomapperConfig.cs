using AutoMapper;
using SGP.Model.Entity;
using SGP.Model.Entity.ViewModels;

namespace SGP.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap(typeof(QueryResult<>), typeof(QueryResult<>));

            CreateMap<CategoriaDoItem, CategoriaDoItemViewModel>().ReverseMap();

            CreateMap<Equipamento, EquipamentoViewModel>().ReverseMap();

            CreateMap<Setor, SetorViewModel>().ReverseMap();
            CreateMap<Fabricante, FabricanteViewModel>().ReverseMap();
            CreateMap<ClassificacaoDeAtivos, ClassificacaoDeAtivosViewModel>().ReverseMap();

        }
    }
}
