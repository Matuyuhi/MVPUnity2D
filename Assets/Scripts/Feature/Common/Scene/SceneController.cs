using Main;
using VContainer;

namespace Feature.Common.Scene
{
    public class SceneController
    {
        private readonly RootInstance _rootInstance;

        [Inject]
        public SceneController(
            RootInstance rootInstance
        )
        {
            // rootInstance.CurrentLevel = RootInstance.Level.Title;
        }
    }
}