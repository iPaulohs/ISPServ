using AutoMapper;
using ISPServ.Domain;
using ISPServ.Domain.User;

namespace ISPServ.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();    
        }
    }
}
