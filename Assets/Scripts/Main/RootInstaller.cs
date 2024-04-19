using Core.Input;
using Feature.Common;
using Feature.Repository;
using VContainer;
using VContainer.Unity;

namespace Main
{
    public class RootInstaller: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            builder.RegisterComponentInHierarchy<InputActionAccessor>();
            builder.Register<RootInstance>(Lifetime.Singleton);
            
            builder.Register<UserRepository>(Lifetime.Singleton);
        }
    }
}