using UnityEngine;

public class PlayerDebuffManager : MonoBehaviour
{
    public int DebuffPoints { get; private set; } = 0;
    private void Start()
    {
        GameController.Instance.SpawnDebuff.ApplyDebuff(gameObject);
    }
}
