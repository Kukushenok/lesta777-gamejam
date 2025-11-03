using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum GameState
{
    MainMenu,
    Gameplay,
    Pause,
    WinScreen,
    LostScreen,
    ChoosePerk
}
public class ProgressData
{
    public readonly DebuffFetcher debuffFetcher;
    public int levelIndex { get; private set; } = 0;
    private List<DebuffSO> currFetchedDebuffs = null;
    public ProgressData(DebuffFetcher debuffFetcher)
    {
        this.debuffFetcher = debuffFetcher;
    }
    private ProgressData(DebuffFetcher fetcher, int levelIdx): this(fetcher)
    {
        levelIndex = levelIdx;
    }
    public void Advance()
    {
        levelIndex++;
    }
    public List<IDebuffDescription> GetNewChoices(int n = 3)
    {
        currFetchedDebuffs = debuffFetcher.GetDebuffs(n);
        return (from s in currFetchedDebuffs select (IDebuffDescription)s).ToList();
    }
    public IDebuff DoChoice(int idx)
    {
        if (currFetchedDebuffs == null) throw new System.Exception("broken flow sorry");
        var result = currFetchedDebuffs[idx];
        debuffFetcher.OnDebuffSelected(result);
        currFetchedDebuffs = null;
        return result;
    }
    public ProgressData Save() => new ProgressData(debuffFetcher.Clone(), levelIndex);
}
public class GameController : Singleton<GameController>
{
    [SerializeField] private DebuffRepositorySO repositorySO;
    [SerializeField] private float pauseTime = 0.1f;
    [SerializeField] private float deathTime = 0.5f;
    [SerializeField] private float perkChooseTime = 1.0f;
    private TimeAnimator timeAnimator = new TimeAnimator(1.0f);
    private ProgressData progressData;
    private ProgressData lastSavedProgressData;
    public GameState State { get; private set; } = GameState.MainMenu;
    public IDebuff SpawnDebuff => progressData.debuffFetcher;
    public static bool IsGameplay
    {
        get
        {
            if (Instance == null) return true;
            return Instance.State == GameState.Gameplay;
        }
    }
    private void Start()
    {
        StartCoroutine(timeAnimator.Cycle());
    }
    public void ToGameplay()
    {
        if(State == GameState.MainMenu)
        {
            progressData = new ProgressData(repositorySO.GetFetcher());
            lastSavedProgressData = progressData.Save();
            DarknessManager.Instance.ResetDarkness(true);
            LevelManager.Instance.ToGameplay(progressData.levelIndex);
            State = GameState.Gameplay;
        } 
        else if(State == GameState.LostScreen)
        {
            progressData = lastSavedProgressData.Save();
            LevelManager.Instance.ToGameplay(progressData.levelIndex);
            DarknessManager.Instance.ResetDarkness(false);
            State = GameState.Gameplay;
            timeAnimator.SetTime(1, pauseTime);
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }
    public void GameOver()
    {
        if (State == GameState.Gameplay && !LevelManager.Instance.Transition)
        {
            State = GameState.LostScreen;
            var x = FindFirstObjectByType<GameplayCanvas>();
            timeAnimator.SetTime(0, deathTime);
            if (x != null) x.ShowDeath();
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }
    public void Advance()
    {
        if(State == GameState.Gameplay && !LevelManager.Instance.Transition)
        {
            progressData.Advance();
            if(LevelManager.Instance.LevelCount <= progressData.levelIndex)
            {
                State = GameState.WinScreen;
                LevelManager.Instance.ToResults();
            } 
            else
            {
                LevelManager.Instance.ToGameplay(progressData.levelIndex);
            }
            lastSavedProgressData = progressData.Save();
        }
    }
    public void DoPause()
    {
        if (State == GameState.Gameplay && !LevelManager.Instance.Transition)
        {
            State = GameState.Pause;
            timeAnimator.SetTime(0, pauseTime);
            PauseCanvasManager.Instance.Pause();
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }
    public void Resume()
    {
        if(State == GameState.Pause)
        {
            State = GameState.Gameplay;
            PauseCanvasManager.Instance.Resume();
            timeAnimator.SetTime(1, pauseTime);
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }

    public void ToMenu()
    {
        if(State == GameState.LostScreen || State == GameState.WinScreen)
        {
            State = GameState.MainMenu;
            LevelManager.Instance.ToMenu();
            timeAnimator.SetTime(1, deathTime);
        }
        if(State == GameState.Pause)
        {
            State = GameState.MainMenu;
            PauseCanvasManager.Instance.Resume();
            timeAnimator.SetTime(1, pauseTime);
            LevelManager.Instance.ToMenu();
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }
    public void DarknessConsumed()
    {
        if (State == GameState.Gameplay)
        {
            State = GameState.ChoosePerk;
            FindFirstObjectByType<DebuffManager>().SetDebuffUI(progressData.GetNewChoices());
            timeAnimator.SetTime(0, perkChooseTime);
        }
        else
        {
            Debug.LogWarning("Can't transition from state " + State);
        }
    }
    public void ApplyPerk(int idx)
    {
        if(State == GameState.ChoosePerk)
        {
            State = GameState.Gameplay;
            var perk = progressData.DoChoice(idx);
            perk.ApplyDebuff(FindFirstObjectByType<PlayerDebuffManager>().gameObject);
            timeAnimator.SetTime(1, perkChooseTime);
        }
    }
    public void Quit()
    {
        if(State == GameState.MainMenu)
        {
#if !UNITY_WEBGL
            Application.Quit();
            Debug.Log("APPLICATION QUIT INVOKED");
#endif
        }
    }
    
}
