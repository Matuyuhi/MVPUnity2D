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
            base.Configure(builder);
            builder.RegisterEntryPoint<GameController>(Lifetime.Scoped);
            builder.RegisterEntryPoint<GameInputProvider>(Lifetime.Scoped);
            
            builder.RegisterComponentInHierarchy<PlayerView>();
            builder.RegisterComponentInHierarchy<InputActionAccessor>();
            builder.Register<PlayerModel>(Lifetime.Scoped);
            builder.Register<PlayerPresenter>(Lifetime.Scoped);
        
            // GameControllerも登録する
            
        }
    }
}