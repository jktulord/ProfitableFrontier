using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using Zenject;

namespace Assets.Scripts.UI.Player
{
    public class PlayerPanelViewInstaller : MonoInstaller
    {
        public ResourceView resourceView;
        public TMP_Text silverLine;
        public TMP_Text apLine;

        public override void InstallBindings()
        {
            Container
            .Bind<ResourceView>()
            .FromInstance(resourceView)
            .AsSingle()
            .NonLazy();
            
            Container
            .Bind<TMP_Text>()
            .FromInstance(silverLine)
            .AsCached()
            .NonLazy();

            Container
            .Bind<TMP_Text>()
            .FromInstance(apLine)
            .AsCached()
            .NonLazy();

        }
    }
}
