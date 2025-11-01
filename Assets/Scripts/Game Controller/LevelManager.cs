using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int index)
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
