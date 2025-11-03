using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class CutsceneListBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private UnityEvent onCutscenesDone;
    int currentIndex = 0;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();

    }

    public void Advance()
    {
        currentIndex++;
        if (currentIndex < sprites.Length)
        {
            image.sprite = sprites[currentIndex];
        } 
        else
        {
            onCutscenesDone?.Invoke();
        }
        
    }
}
