using Assets.Scripts.Dungeon;
using Assets.Scripts.Models.Buildings.Extensions;
using Assets.Scripts.Models.Buildings.Kinds;
using Assets.Scripts.Models.Heroes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HeroSystem : MonoBehaviour
{
    public PlayerSystem PlayerSystem;
    public MainDungeonManager MainDungeonManager;
    private PopUpSystem PopUpSystem;

    public List<Hero> Heroes;

    [Inject]
    private void Construct(PlayerSystem playerSystem, PopUpSystem popUpSystem)
    {
        PlayerSystem = playerSystem;
        PopUpSystem = popUpSystem;
        Heroes = new List<Hero>();
    }

    public void NextTurn()
    {
        foreach (Hero hero in Heroes)
        {
            hero.NextTurn();
        }
        MainDungeonManager.NextTurn();
    }

    public List<Hero> Migration(int amount)
    {
        List<Hero> MigratedHeroes = new List<Hero>();
        for (int i = 0; i < amount; i++)
        {
            Hero newHero = new Hero(this, PopUpSystem);
            
            if (PlayerSystem.Player.Buildings.FindBuildingWithSpace() != null)
            {
                GetHome(newHero);
                Heroes.Add(newHero);
                MigratedHeroes.Add(newHero);
            }

        }
        return MigratedHeroes;
    }

    public void GetHome(Hero hero)
    {
        House house = (House)PlayerSystem.Player.Buildings.FindBuildingWithSpace();
        house.Occupants.Add(hero);
        hero.Home = house;
    }

    public void HeroEnterDungeon(Hero hero)
    {
        MainDungeonManager.HeroEnter(hero);
    }


}
