using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CustomSystemInstaller : MonoInstaller
{
    public Canvas canvas;

    public HeroSystem heroSystem;
    public PlayerSystem playerSystem;
    public TileSystem tileSystem;
    public AnalysisSystem analysisSystem;
    public SpaceForStatusPops spaceForStatusPops;
    public PopUpSystem popUpSystem;

    private GameObject PopUpSystemPrefab;

    public override void InstallBindings()
    {
        CanvasBind();
        PopUpSystemPrefab = Resources.Load<GameObject>("Prefabs/Systems/PopUpSystem");
        //PopUpSystemBind();
        SystemBind();
    }

    public void CanvasBind()
    {
        Container
            .Bind<Canvas>()
            .FromInstance(canvas)
            .AsSingle()
            .NonLazy();
    }

    public void PopUpSystemBind()
    {
        PopUpSystem popUpSystem = Container.InstantiatePrefabForComponent<PopUpSystem>(PopUpSystemPrefab);

        Container
            .Bind<PopUpSystem>()
            .FromInstance(popUpSystem)
            .AsSingle()
            .NonLazy();

    }

    public void SystemBind()
    {
        Container
            .Bind<HeroSystem>()
            .FromInstance(heroSystem)
            .AsSingle()
            .NonLazy();
        Container
            .Bind<PlayerSystem>()
            .FromInstance(playerSystem)
            .AsSingle()
            .NonLazy();
        Container
            .Bind<TileSystem>()
            .FromInstance(tileSystem)
            .AsSingle()
            .NonLazy();
        Container
            .Bind<AnalysisSystem>()
            .FromInstance(analysisSystem)
            .AsSingle()
            .NonLazy();
        Container
            .Bind<PopUpSystem>()
            .FromInstance(popUpSystem)
            .AsSingle()
            .NonLazy();
        Container
            .Bind<SpaceForStatusPops>()
            .FromInstance(spaceForStatusPops)
            .AsSingle()
            .NonLazy();

    }
}
