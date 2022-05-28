using AutoMapper;
using SGP.Model.Entity;
using SGP.Model.Entity;

namespace SGP.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap(typeof(QueryResult<>), typeof(QueryResult<>));

            CreateMap<CategoriaDoItem, CategoriaDoItemDTO>().ReverseMap();
            CreateMap<CategoriaDoItemDTO, CategoriaDoItemDTQ>().ReverseMap();

            CreateMap<Equipamento, EquipamentoDTO>().ReverseMap();

            CreateMap<Setor, SetorDTO>().ReverseMap();
            CreateMap<Fabricante, FabricanteDTO>().ReverseMap();
            CreateMap<ClassificacaoDeAtivos, ClassificacaoDeAtivosDTO>().ReverseMap();

        }
    }
}
