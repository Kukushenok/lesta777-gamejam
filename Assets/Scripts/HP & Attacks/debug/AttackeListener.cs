using UnityEngine;

public class AttackeListener : MonoBehaviour
{
    public void OnAttack()
    {
        Debug.Log("Атака!");
    }

    public void OnDeath()
    {
        Debug.Log("Помер");
    }
}
