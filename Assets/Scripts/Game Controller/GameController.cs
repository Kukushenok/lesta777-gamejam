using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameController : MonoBehaviour
{
    private IState _currentState;

    private MenuState _menuState = new();

    private BattleState _battleState = new();

    private GameOverState _gameOverState = new();

    private PauseState _pauseState = new();

    private SkillSelectionState _skillSelectionState = new();

    private VictoryState _victoryState = new();

    public static GameController Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private async UniTask ChangeStateAsync(IState newState)
    {
        if (_currentState != null) await _currentState.OnExit();
        _currentState = newState;
        await _currentState.OnEnterAsync();
    }

    public void Menu() => ChangeStateAsync(_menuState).Forget();

    public void Battle() => ChangeStateAsync(_battleState).Forget();

    public void GameOver() => ChangeStateAsync(_gameOverState).Forget();

    public void Pause() => ChangeStateAsync(_pauseState).Forget();

    public void SkillSelection() => ChangeStateAsync(_skillSelectionState).Forget();

    public void Victory() => ChangeStateAsync(_victoryState).Forget();
}
