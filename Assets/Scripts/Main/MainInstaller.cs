using Core.Input;
using Feature.Common;
using Feature.Models;
using Feature.Presenters;
using Feature.Views;
using VContainer;
using VContainer.Unity;

namespace Main
{
    public class MainInstaller: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            builder.RegisterEntryPoint<GameController>(Lifetime.Scoped);
            
            builder.RegisterComponentInHierarchy<PlayerView>();
            builder.Register<PlayerModel>(Lifetime.Scoped);
            builder.Register<PlayerPresenter>(Lifetime.Scoped);
            builder.Register<GameState>(Lifetime.Scoped);

        }
    }
}