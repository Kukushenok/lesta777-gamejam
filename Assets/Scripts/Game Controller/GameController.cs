using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class GameController : MonoBehaviour
{
    private GameState _currentGameState;

    private List<IOnGameStateChange> events = new();

    public static GameController Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeGameState(GameState newState)
    {
        _currentGameState = newState;
        UniTask.WhenAll(from s in events select s.GameStateChanged(_currentGameState));
    }

    public void AddCallback(IOnGameStateChange ev) => events.Add(ev);

    public void RemoveCallback(IOnGameStateChange ev) => events.Remove(ev);
}
