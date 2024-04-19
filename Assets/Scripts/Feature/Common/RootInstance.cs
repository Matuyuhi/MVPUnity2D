using Core.Input;
using VContainer;

namespace Feature.Common
{
    public class RootInstance
    {
        private readonly InputController _inputController;
        private readonly TitleState _titleState;

        private readonly GameState _gameState;

        public enum Level
        {
            Title,
            Game,
            Result
        }
        public GameState GameState => _gameState;
        [Inject]
        public RootInstance(
            InputActionAccessor inputActionAccessor
        )
        {
            _gameState = new GameState();
            _inputController = new InputController(inputActionAccessor, _gameState);
        }
        
        public Level CurrentLevel { get; private set; }
        
    }
}