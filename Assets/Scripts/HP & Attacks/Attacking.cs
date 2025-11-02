using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] GameObject attackObjectPrefab;

    public void Attack()
    {
        Instantiate(attackObjectPrefab, this.transform).GetComponent<AttackObject>().Attack(new Vector2(-1,0),10,1,1);
    }
}
