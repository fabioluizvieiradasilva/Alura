using AutoMapper;
using FilmesAPI.Data.DTOs.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile: Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao,ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeIncio, opt => opt
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }

    }
}
