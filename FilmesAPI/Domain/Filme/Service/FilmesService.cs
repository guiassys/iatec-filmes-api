using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Domain.Filme.Data;
using FilmesApi.Domain.Filme.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Domain.Filme.Service
{
    public class FilmesService
    {
        private ValidateFilmesService validateFilmeService = new ValidateFilmesService();
        private FilmeRepository _context;
        private IMapper _mapper;

        public FilmesService(FilmeRepository context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public FilmeEntity InsertFilme(CreateFilmeDto filmeDto)
        {
            validateFilmeService.validateFilmeEntity(filmeDto);
            FilmeEntity filme = _mapper.Map<FilmeEntity>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return filme;
        }

        public IEnumerable<ReadFilmeDto> GetFilmes(int skip, int take)
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }

        public FilmeEntity GetFilmeById(int id)
        {
            FilmeEntity filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            validateFilmeService.validateResultSearchFilmeById(id, filme);
            return filme;
        }

        public FilmeEntity UpdateFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            validateFilmeService.validateResultSearchFilmeById(id, filme);
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return filme;
        }

        public void DeleteFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            validateFilmeService.validateResultSearchFilmeById(id, filme);
            _context.Remove(filme);
            _context.SaveChanges();
        }

    }
}
