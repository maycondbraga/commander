using AutoMapper;
using Command.Dto.Entities;
using Commander.Model.Entities;

namespace Commander.Web.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CommandModel, CommandReadDto>().ReverseMap();
            CreateMap<CommandModel, CommandCreateDto>().ReverseMap();
            CreateMap<CommandModel, CommandUpdateDto>().ReverseMap();
        }
    }
}
