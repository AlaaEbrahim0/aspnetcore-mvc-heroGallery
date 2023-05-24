using System.Collections.Generic;

namespace HeroManagement.Models
{
    public interface IHeroRepository
    {
        IEnumerable<Hero> GetAllHeros();
        Hero GetHero(int Id);
        Hero AddHero(Hero Hero);
        Hero UpdateHero(Hero HeroChanges);
        Hero DeleteHero(int id);

    }
}