using AutoMapper;
using FilmesApi.Domain.Filme.Data;
using FilmesApi.Domain.Filme.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<CreateFilmeDto, FilmeEntity>();
        CreateMap<UpdateFilmeDto, FilmeEntity>();
        CreateMap<FilmeEntity, UpdateFilmeDto>();
        CreateMap<FilmeEntity, ReadFilmeDto>();
    }
}
