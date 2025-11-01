using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Menu()
    {
        Debug.Log("Menu");
    }

    public void Battle()
    {
        Debug.Log("Battle");
    }

    public void SkillSelection()
    {
        Debug.Log("SkillSelection");
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void Victory()
    {
        Debug.Log("Victory");
    }
}
