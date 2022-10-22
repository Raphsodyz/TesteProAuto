using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Identity;

namespace Application.Mapper
{
    public class CadastroMapper : Profile
    {
        public CadastroMapper()
        {
            CreateMap<AssociadoDTO, Associado>();
            CreateMap<CarroDTO, Carro>();
            CreateMap<EnderecoDTO, Endereco>();
            CreateMap<LoginDTO, CadastroUser>();
            CreateMap<RegisterDTO, Associado>();
        }
    }
}
