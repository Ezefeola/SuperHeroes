using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.TestManagement.TestPlanning.WebApi;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Repositories;
using System.Diagnostics;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroRepository _superHeroRepository;
        private readonly IMapper _mapper;

        public SuperHeroController(ISuperHeroRepository superHeroRepository, IMapper mapper)
        {
            this._superHeroRepository = superHeroRepository;
            this._mapper = mapper;
        }

        [HttpGet, Authorize] 
        public async Task<Ok<List<SuperHeroDTO>>> GetAllHeroes()
        {
            var superHeroes = await _superHeroRepository.GetAll();
            var superHeroesDTO = _mapper.Map<List<SuperHeroDTO>>(superHeroes);
            return TypedResults.Ok(superHeroesDTO);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<Ok<SuperHeroDTO>> GetHero(int id)
        { 
            var superHero = await _superHeroRepository.GetById(id);
            var superHeroDTO = _mapper.Map<SuperHeroDTO>(superHero);
            return TypedResults.Ok(superHeroDTO);
        }

        [HttpPost, Authorize]
        public async Task<Created<SuperHeroDTO>> CreateHero(CreateSuperHeroDTO createSuperHeroDTO)
        {
            var superHero = _mapper.Map<SuperHero>(createSuperHeroDTO);

            var id = await _superHeroRepository.Create(superHero);

            var superHeroDTO = _mapper.Map<SuperHeroDTO>(superHero);

            return TypedResults.Created($"/superHeroes/{id}", superHeroDTO);
        }

        [HttpPut("{id}"), Authorize] 
        public async Task<NoContent> UpdateHero(int id, UpdateSuperHeroDTO updateSuperHeroDTO)
        {
            var superHeroToUpdate = _mapper.Map<SuperHero>(updateSuperHeroDTO);

            await _superHeroRepository.Update(superHeroToUpdate);

            return TypedResults.NoContent();
        }

        [HttpDelete("{id}"), Authorize] 
        public async Task<NoContent> DeleteHero(int id)
        {
            await _superHeroRepository.Delete(id);
            return TypedResults.NoContent();
        }
    }
}
