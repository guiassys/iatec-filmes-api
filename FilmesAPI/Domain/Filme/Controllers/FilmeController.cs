using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Domain.Filme.Data;
using FilmesApi.Domain.Filme.Models;
using FilmesApi.Domain.Filme.Service;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Domain.Filme.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmesService filmesService;
    private FilmeRepository _context;
    private IMapper _mapper;

    public FilmeController(FilmeRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        filmesService = new FilmesService(_context, _mapper);
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
    {
        FilmeEntity filme = filmesService.InsertFilme(filmeDto);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    /// <summary>
    /// Recupera lista de filmes utilizando paginação
    /// </summary>
    /// <param name="skip">Informe o indice da paginação</param>
    /// <param name="take">Informe a quantidade de registros</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return filmesService.GetFilmes(skip, take);
    }

    /// <summary>
    /// Recupera filme aplicando filtro sobre o identificador do objeto
    /// </summary>
    /// <param name="id">Informe o identificador do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a busca seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = filmesService.GetFilmeById(id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto);
    }

    /// <summary>
    /// Atualiza filme aplicando filtro sobre o identificador do objeto
    /// </summary>
    /// <param name="id">Informe o identificador do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        filmesService.UpdateFilme(id, filmeDto);
        return NoContent();
    }

    /// <summary>
    /// Deleta filme aplicando filtro sobre o identificador do objeto
    /// </summary>
    /// <param name="id">Informe o identificador do objeto</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a remoção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        filmesService.DeleteFilme(id);
        return NoContent();
    }

    /// <summary>
    /// Atualiza filme parcialmente aplicando filtro sobre o identificador do objeto
    /// </summary>
    /// <param name="id">Informe o identificador do objeto</param>
    /// <param name="patch">Objeto json representando os atributos que devem ser alterados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualização seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }
}
