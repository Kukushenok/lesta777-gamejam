using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] GameObject Transform;
    bool shit = true;

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("stop")&&shit)
        {
            Transform.GetComponent<SpriteRenderer>().color = Color.black;
            Transform.transform.position = new Vector3(0,0,-40);
            shit = false;
            GameController.Instance.ToMenu();
        }
    }
}
