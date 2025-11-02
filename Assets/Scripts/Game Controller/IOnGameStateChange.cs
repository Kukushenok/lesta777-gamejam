using Cysharp.Threading.Tasks;

public interface IOnGameStateChange
{
    public UniTask GameStateChanged(GameState state);
}

public enum GameState
{
    Menu,
    Pause,
    Battle,
    GameOver,
    Selection,
    Victory
}
