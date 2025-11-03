using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class RandomImage : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    public void Awake()
    {
        GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
