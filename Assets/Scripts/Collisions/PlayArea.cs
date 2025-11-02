using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private float upperBoundaryHeight;

    Camera cam;
    GameObject lowerBoundary;
    GameObject upperBoundary;

    private void Awake()
    {
        
    }
}
