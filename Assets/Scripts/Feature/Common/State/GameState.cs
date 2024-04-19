namespace Feature.Common
{
    public class GameState
    {
        
        // ステートは細かく分け、メソッドで状態を取得する
        public enum State 
        {
            None,
            // 初期化処理
            Started,
            // in game
            Playing,
            // pause中
            Paused,
            // 終了処理
            DoEnded,
            // 終了
            Finished
        }
        
        private State _state = State.None;

        public State GetState => _state;

        // ゲーム画面内で操作可能かのフラグ(メニュー含む)
        public bool IsPlaying()
        {
            return _state == State.Playing || _state == State.Paused;
        }


        public void Initialize()
        {
            _state = State.Started;
        }
        
        public void Start()
        {
            _state = State.Playing;
        }
    }
}