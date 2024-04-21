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
            Finished,
        }

        public State GetState { get; private set; } = State.None;

        // ゲーム画面内で操作可能かのフラグ(メニュー含む)
        public bool IsPlaying() => this.GetState == State.Playing || this.GetState == State.Paused;


        public void Initialize()
        {
            this.GetState = State.Started;
        }

        public void Start()
        {
            this.GetState = State.Playing;
        }
    }
}