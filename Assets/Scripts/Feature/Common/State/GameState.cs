namespace Feature.Common
{
    public class GameState
    {
        
        // ステートは細かく分け、メソッドで状態を取得する
        public enum State 
        {
            None,
            Started,
            Playing,
            Paused,
            DoEnded,
            Finished
        }
        
        private State _state;
        
        
        
        public GameState()
        {
            _state = State.None;
        }
        public void Initialize()
        {
            _state = State.Started;
        }
    }
}