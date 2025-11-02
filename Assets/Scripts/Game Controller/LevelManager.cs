using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public bool Transition { get; private set; }
    [field: SerializeField] public int LevelCount { get; private set; }
    [SerializeField] private int mainMenuIndex = 0;
    [SerializeField] private int levelStartIndex;
    [SerializeField] private int resultsIndex;
    public void ToResults()
    {
        if (Transition) return;
        LoadSceneByIndex(resultsIndex).Forget();
    }
    public void ToGameplay(int levelID)
    {
        if (Transition) return;
        LoadSceneByIndex(levelStartIndex + levelID).Forget();
    }
    public void ToMenu()
    {
        if (Transition) return;
        LoadSceneByIndex(mainMenuIndex).Forget();
    }
    private async UniTask LoadSceneByIndex(int index)
    {
        Transition = true;
        if (IsSceneValid(index))
        {
            await SceneManager.LoadSceneAsync(index);
        }
        Transition = false;
    }

    private bool IsSceneValid(int index)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        return index >= 0 && index < sceneCount;
    }
}
