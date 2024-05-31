using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Repositories
{
    public interface ISuperHeroRepository
    {
        Task<int> Create(SuperHero superHero);
        Task Delete(int id);
        Task<List<SuperHero>> GetAll();
        Task<SuperHero?> GetById(int id);
        Task Update(SuperHero superHero);
    }
}