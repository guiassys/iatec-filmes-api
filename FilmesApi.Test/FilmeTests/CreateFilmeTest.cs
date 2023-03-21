
using FilmesApi.Domain.Filme.Models;
using FilmesApi.Domain.Filme.Service;

namespace FilmesApi.Test.FilmeTests
{
    public class CreateFilmeTest
    {
        [Fact(DisplayName ="Verifica se o serviço de validação do objeto FilmeEntity retorna verdadeiro para objetos válidos")]
        public void NaoDeveFalharAoValidarObjetoFilmeEntityValido() {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();

            FilmeEntity filme = new FilmeEntity();
            filme.Titulo = "Título Teste";
            filme.Genero = "Genero Teste";
            filme.Duracao = 600;
            // Act
            var result = validateFilmesService.validateFilmeEntity(filme);
            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Deve retornar falso quando o Titulo for nulo")]
        public void DeveRetornarFalsoQuandoFilmeNaoPossuiTitulo()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();

            FilmeEntity filme = new FilmeEntity();
            filme.Genero = "Genero Teste";
            filme.Duracao = 600;
            // Act
            var result = validateFilmesService.validateFilmeEntity(filme);
            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Deve retornar falso quando o Genero for nulo")]
        public void DeveRetornarFalsoQuandoGeneroForNulo()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            FilmeEntity filme = new FilmeEntity();
            filme.Titulo = "Titulo Teste";
            filme.Duracao = 600;
            // Act
            var result = validateFilmesService.validateFilmeEntity(filme);
            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Deve retornar falso se a Duração for menor que 70")]
        public void DeveRetornarFalsoQuandoDuracaoForMenor70()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            FilmeEntity filme = new FilmeEntity();
            filme.Titulo = "Titulo Teste";
            filme.Genero = "Genero Teste";
            filme.Duracao = 69;
            // Act
            var result = validateFilmesService.validateFilmeEntity(filme);
            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Deve retornar falso se a Duração for mair que 600")]
        public void DeveRetornarFalsoQuandoDuracaoForMaior600()
        {
            // Arrange
            ValidateFilmesService validateFilmesService = new ValidateFilmesService();
            FilmeEntity filme = new FilmeEntity();
            filme.Titulo = "Titulo Teste";
            filme.Genero = "Genero Teste";
            filme.Duracao = 601;
            // Act
            var result = validateFilmesService.validateFilmeEntity(filme);
            // Assert
            Assert.False(result);
        }

    }
}
