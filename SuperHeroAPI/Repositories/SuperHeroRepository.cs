using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.DTOs;
using SuperHeroAPI.Entities;
using System.Collections;

namespace SuperHeroAPI.Repositories
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor httpContextAccesor;

        public SuperHeroRepository(ApplicationDbContext DbContext, IHttpContextAccessor httpContextAccesor)
        {
            _dbContext = DbContext;
            this.httpContextAccesor = httpContextAccesor;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            return await _dbContext.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> GetById(int id)
        {

            return await _dbContext.SuperHeroes.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<int> Create(SuperHero superHero)
        {
            _dbContext.Add(superHero);
            await _dbContext.SaveChangesAsync();
            return superHero.Id;
        }

        public async Task Update(SuperHero superHero)
        {
            _dbContext.Update(superHero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await _dbContext.SuperHeroes.Where(s => s.Id == id).ExecuteDeleteAsync();
        }
    }
}
