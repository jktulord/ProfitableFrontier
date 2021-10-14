using Assets.Scripts.Dungeon;
using Assets.Scripts.Models.Entity;
using Assets.Scripts.Models.Entity.Enemy;
using Assets.Scripts.Models.Heroes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BattleSpace : MonoBehaviour
{
    public MainDungeonManager MainDungeonManager;
    public string Name;

    public float GoblenSpawnChance;
    public float HobGoblenSpawnChance;

    public HeroSpot[] HeroSpots;
    public HeroSpot[] EnemySpots;

    public List<EntityBase> Heroes;
    public List<EntityBase> Enemies;

    private string BattleLogString;

    public void Load()
    {
        Heroes = new List<EntityBase>();
        //Heroes.Add(new Hero(HeroSystem, PopUpSystem));
        //Heroes.Add(new Hero(HeroSystem, PopUpSystem));
        Enemies = new List<EntityBase>();
        //Enemies.Add(GetEnemy.Goblen());
        //Enemies.Add(GetEnemy.HobGoblen());
        //Heroes.Add(new Hero(HeroSystem, PopUpSystem));
        Refresh();
    }

    

    public void Turn()
    {
        MainDungeonManager.BattleLogAdd("------"+Name+"----");
        HeroesTurn();
        EnemyTurn();
        EnemyDeathTurn();
        SpawnTurn();
        Refresh();
    }

    public void HeroesTurn()
    {
        for (int i = 0; i < Heroes.Count; i++)
        {
            Hero Hero = (Hero)Heroes[i];
            //int action = Random.Range(0, 0);
            if (Hero.Hp.Amount < Hero.Hp.Max / 3) // Проверка на хп
            {
                BattleActions.EscapeFromDungeon(this, Hero);

            }
            else if (Enemies.Count > 0) // Проверка на наличие противников
            {
                EntityBase Enemy = Enemies[Random.Range(0, Enemies.Count)];
                BattleActions.AttackEntity(this, Hero, Enemy);
            }
            else
            {
                MainDungeonManager.BattleLogAdd(Hero.Name + " wants to move next");
                MainDungeonManager.MoveHeroToNextLocation(Hero, this);
            }
        }
    }

    public void EnemyTurn()
    {
        foreach (Enemy Enemy in Enemies)
        {

            int action = Random.Range(0, 0);
            if (Heroes.Count > 0)
            {
                EntityBase Hero = Heroes[Random.Range(0, Heroes.Count)];
                BattleActions.AttackEntity(this, Enemy, Hero);
            }
        }
    }

    public void EnemyDeathTurn()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].Hp.IfDead)
            {
                Enemy Enemy = (Enemy)Enemies[i];
                Hero Hero = (Hero)Heroes[Random.Range(0, Heroes.Count)];

                int loot = Enemy.Loot.Get();
                Hero.Loot += loot;
                Hero.Level.CurExp += 1;
                MainDungeonManager.BattleLogAdd(Enemies[i].Name + " Died");
                MainDungeonManager.BattleLogAdd(Hero.Name + " got " + loot + " loot");


                Enemies.Remove(Enemies[i]);
                Refresh();
            }
        }
    }

    public void SpawnTurn()
    {
        //int ChanceValue = Random.Range(1, 100);

        if (Random.Range(1, 101) < GoblenSpawnChance)
        {
            SpawnEnemy(GetEnemy.Goblenlv1());
        }
        if (Random.Range(1, 101) < HobGoblenSpawnChance)
        {
            SpawnEnemy(GetEnemy.HobGoblenlv3());
        }
    }
    public void SpawnEnemy(Enemy enemy)
    {
        if (Enemies.Count + 1 <= EnemySpots.Length)
        {
            Enemies.Add(enemy);
            MainDungeonManager.BattleLogAdd(enemy.Name + " Spawned");
            Refresh();
        }
    }

    public void HeroMoveHere(Hero hero, BattleSpace previousBattleSpace)
    {
        if (Heroes.Count < HeroSpots.Length)
        {
            Heroes.Add(hero);
            previousBattleSpace.Heroes.Remove(hero);
            MainDungeonManager.BattleLogAdd(hero.Name + " moved to " + previousBattleSpace.name);
            Refresh();
            previousBattleSpace.Refresh();
        }
    }

    public void Refresh()
    {
        foreach (HeroSpot heroSpot in HeroSpots)
        {
            heroSpot.Clear();
        }
        foreach (HeroSpot heroSpot in EnemySpots)
        {
            heroSpot.Clear();
        }
        for (int i = 0; i < Heroes.Count; i++)
        {
            HeroSpots[i].Entity = Heroes[i]; ///--

            //HeroSpots[i]
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            EnemySpots[i].Entity = Enemies[i];

            //HeroSpots[i]
        }
    }
}
