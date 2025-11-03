using UnityEngine;

public class AddDarknessOnDestroy: MonoBehaviour
{
    [SerializeField] private float _addDarkness;
    private void OnDestroy()
    {
        DarknessManager.Instance.AddDarkness(_addDarkness);
    }
}
