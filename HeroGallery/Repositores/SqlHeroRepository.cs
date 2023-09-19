using System.Collections.Generic;
using System.Threading.Tasks;
using HeroManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;

namespace HeroGallery.Repositores
{
    public class SqlHeroRepository : IHeroRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<IHeroRepository> logger;

        public SqlHeroRepository(AppDbContext context, ILogger<SqlHeroRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Hero> AddHero(Hero Hero)
        {
            await context.Heros.AddAsync(Hero);
            context.SaveChanges();
            return Hero;
        }

        public Hero DeleteHero(int id)
        {
            Hero hero = context.Heros.Find(id);
            if (hero != null)
            {
                context.Heros.Remove(hero);
                context.SaveChanges();
            }
            return hero;

        }

        public async Task<IEnumerable<Hero>> GetAllHeros()
        {
            return await context.Heros.AsNoTracking().ToListAsync();
        }

        public async Task<Hero> GetHero(int Id)
        {
            return await context.Heros.FindAsync(Id);
        }

        public Hero UpdateHero(Hero HeroChanges)
        {
            var hero = context.Heros.Update(HeroChanges);
            hero.State = EntityState.Modified;
            context.SaveChanges();
            return HeroChanges;
        }
    }
}
