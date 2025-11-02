using Assets.Scripts.Systems;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void LoadSceneByIndex(int index)
    {
        if (IsSceneValid(index))
        {
            SceneManager.LoadScene(index);
        }
    }

    private bool IsSceneValid(int index)
    {
        int sceneCount = EditorBuildSettings.scenes.Length;
        return index >= 0 && index < sceneCount;
    }
}
