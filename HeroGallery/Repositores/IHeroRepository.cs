namespace HeroGallery.Repositores;

public interface IHeroRepository
{
    Task<IEnumerable<Hero>> GetAllHeros();
    Task<Hero> GetHero(int Id);
	Task<Hero> AddHero(Hero Hero);
    Hero UpdateHero(Hero HeroChanges);
    Hero DeleteHero(int id);

}
 