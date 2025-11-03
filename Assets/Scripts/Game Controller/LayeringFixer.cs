using UnityEngine;

public class LayeringFixer : MonoBehaviour
{
    private const float EPS = 0.1f;
    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.parent.position.y * EPS);
    }
}
