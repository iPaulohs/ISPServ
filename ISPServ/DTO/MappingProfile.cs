using AutoMapper;
using ISPServ.Domain;
using ISPServ.Domain.User;

namespace ISPServ.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, AdminDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap(); 
            CreateMap<Superadmin, SuperadminDTO>().ReverseMap();
        }
    }
}
