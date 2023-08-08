using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Logging;

namespace HeroManagement.Models
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
        public Hero AddHero(Hero Hero)
        {
            context.Heros.Add(Hero);
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

        public IEnumerable<Hero> GetAllHeros()
        {
            return context.Heros.AsNoTracking();
        }

        public Hero GetHero(int Id)
        {
            return context.Heros.Find(Id);
        }

        public Hero UpdateHero(Hero HeroChanges)
        {
            var hero = context.Heros.Attach(HeroChanges);
            hero.State = EntityState.Modified;
            context.SaveChanges();
            return HeroChanges;
        }
    }
}
