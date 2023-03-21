
using System.Data.SqlTypes;
using FilmesApi.Domain.Filme.Models;


namespace FilmesApi.Domain.Filme.Service
{
    public class ValidateFilmesService
    {

        public bool validateFilmeEntity(FilmeEntity filme) {
            bool result = true;
            if (filme == null)
            {
                result = false;
            }

            if (string.IsNullOrEmpty(filme.Titulo))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(filme.Genero))
            {
                result = false;
            }

            if (null == filme.Duracao)
            {
                result = false;
            }

            if (filme.Duracao < 70)
            {
                result = false;
            }

            if (filme.Duracao > 600)
            {
                result = false;
            }

            return result;
        }

    }
}
