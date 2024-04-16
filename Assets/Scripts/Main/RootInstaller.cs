using Feature.Repository;
using VContainer;
using VContainer.Unity;

namespace Main
{
    public class RootInstaller: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.Register<UserPreference>(Lifetime.Singleton);
        }
    }
}