#region

using Interfaces;
using VContainer;

#endregion

namespace Main
{
    public class RootInstance
    {
        [Inject]
        public RootInstance()
        {
        }

        public ISceneDataModel CurrentDataModel { private get; set; }
        
        public T GetCurrentDataModel<T>() where T : ISceneDataModel
        {
            return (T)this.CurrentDataModel;
        }
    }
}