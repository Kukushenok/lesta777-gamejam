using Assets.Scripts.Systems;
using UnityEngine;

public class GameController : Singleton<GameController>
{
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
