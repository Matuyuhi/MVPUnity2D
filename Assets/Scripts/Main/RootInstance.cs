using VContainer;

namespace Main
{
    public class RootInstance
    {

        public enum Level
        {
            Title,
            Game,
            Result
        }

        [Inject]
        public RootInstance()
        {
        }
        
        public Level CurrentLevel { get; private set; }
        
        
    }
}