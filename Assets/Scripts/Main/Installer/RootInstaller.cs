#region

using Core.Input;
using Feature.Common.Scene.Generated;
using Feature.Repository;
using VContainer;
using VContainer.Unity;

#endregion

namespace Main.Installer
{
    public class RootInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<InputActionAccessor>();
            builder.Register<RootInstance>(Lifetime.Singleton);

            builder.Register<UserRepository>(Lifetime.Singleton);
        }
    }
}