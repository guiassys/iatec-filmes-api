
using System.Data.SqlTypes;
using FilmesApi.Domain.Filme.Data;
using FilmesApi.Domain.Filme.Models;
using FilmesApi.Domain.Filme.Util;

namespace FilmesApi.Domain.Filme.Service
{
    public class ValidateFilmesService
    {

        public void validateFilmeEntity(CreateFilmeDto createFilmeDto)
        {
            if (createFilmeDto == null)
            {
                throw new ArgumentException(FilmesConstants.ERROR_INVALID_OBJECT);
            }

            if (string.IsNullOrEmpty(createFilmeDto.Titulo))
            {
                throw new ArgumentException(FilmesConstants.ERROR_REQUIRED_ATTRIBUTE+"Título");
            }

            if (string.IsNullOrEmpty(createFilmeDto.Genero))
            {
                throw new ArgumentException(FilmesConstants.ERROR_REQUIRED_ATTRIBUTE + "Gênero");
            }

            if (createFilmeDto.Duracao < FilmesConstants.DURACAO_MIN_TIME)
            {
                throw new ArgumentException(FilmesConstants.ERROR_INVALID_ATTRIBUTE+ "Duração não pode ser menor que "+FilmesConstants.DURACAO_MIN_TIME);
            }

            if (createFilmeDto.Duracao > FilmesConstants.DURACAO_MAX_TIME)
            {
                throw new ArgumentException(FilmesConstants.ERROR_INVALID_ATTRIBUTE + "Duração não pode ser maior que " + FilmesConstants.DURACAO_MAX_TIME);
            }
        }

        public void validateResultSearchFilmeById(int id, FilmeEntity filme)
        {
            if (filme == null)
            {
                throw new Exception("Erro ao buscar o filme aplicando filtro pelo Id = " + id);
            }
        }

    }
}
