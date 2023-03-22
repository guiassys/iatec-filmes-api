
using FilmesApi.Domain.Filme.Data;
using FilmesApi.Domain.Filme.Models;
using FilmesApi.Domain.Filme.Service;
using FilmesApi.Domain.Filme.Util;

namespace FilmesApi.Test.FilmeTests
{
    public class CreateFilmeTest
    {


        [Fact(DisplayName = "Deve retornar Exception se o objeto for nulo")]
        public void DeveRetornarExeptionFilmeDtoNulo()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            CreateFilmeDto createFilmeDto = null;

            // Act
            var exception = Assert.Throws<ArgumentException>(() => validateFilmesService.validateFilmeEntity(createFilmeDto));

            // Assert
            Assert.Contains(FilmesConstants.ERROR_INVALID_OBJECT, exception.Message);
        }

        [Fact(DisplayName = "Deve retornar Exception se a Duração for maior que DURACAO_MAX_TIME")]
        public void DeveRetornarExeptionDuracao601()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            CreateFilmeDto createFilmeDto = new CreateFilmeDto();
            createFilmeDto.Titulo = "Titulo Teste";
            createFilmeDto.Genero = "Genero Teste";
            createFilmeDto.Duracao = FilmesConstants.DURACAO_MAX_TIME +1;
            // Act
            var exception = Assert.Throws<ArgumentException>(() => validateFilmesService.validateFilmeEntity(createFilmeDto));
            // Assert
            Assert.Contains(FilmesConstants.ERROR_INVALID_ATTRIBUTE, exception.Message);
        }

        [Fact(DisplayName = "Deve retornar Exception se a Duração for menor que DURACAO_MIN_TIME")]
        public void DeveRetornarExeptionDuracao69()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            CreateFilmeDto createFilmeDto = new CreateFilmeDto();
            createFilmeDto.Titulo = "Titulo Teste";
            createFilmeDto.Genero = "Genero Teste";
            createFilmeDto.Duracao = FilmesConstants.DURACAO_MIN_TIME - 1;
            // Act
            var exception = Assert.Throws<ArgumentException>(() => validateFilmesService.validateFilmeEntity(createFilmeDto));
            // Assert
            Assert.Contains(FilmesConstants.ERROR_INVALID_ATTRIBUTE, exception.Message);
        }

        [Fact(DisplayName = "Deve retornar Exception se o Título não for informado")]
        public void DeveRetornarExeptionTituloNaoInformado()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            CreateFilmeDto createFilmeDto = new CreateFilmeDto();
            createFilmeDto.Genero = "Genero Teste";
            createFilmeDto.Duracao = FilmesConstants.DURACAO_MIN_TIME;
            // Act
            var exception = Assert.Throws<ArgumentException>(() => validateFilmesService.validateFilmeEntity(createFilmeDto));

            // Assert
            Assert.Contains(FilmesConstants.ERROR_REQUIRED_ATTRIBUTE, exception.Message);
        }

        [Fact(DisplayName = "Deve retornar Exception se o Gênero não for informado")]
        public void DeveRetornarExeptionGeneroNaoInformado()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            CreateFilmeDto createFilmeDto = new CreateFilmeDto();
            createFilmeDto.Titulo = "Título Teste";
            createFilmeDto.Duracao = FilmesConstants.DURACAO_MIN_TIME;
            // Act
            var exception = Assert.Throws<ArgumentException>(() => validateFilmesService.validateFilmeEntity(createFilmeDto));

            // Assert
            Assert.Contains(FilmesConstants.ERROR_REQUIRED_ATTRIBUTE, exception.Message);
        }
    }
}
