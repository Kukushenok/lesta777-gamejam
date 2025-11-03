using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySound : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioClip[] footstepClips;
    public float stepDelay = 0.4f;

    private float stepTimer;

    private void Update()
    {
        if (rb == null || footstepClips.Length == 0) return;

        if (rb.linearVelocity.sqrMagnitude > 0.05f)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDelay)
            {
                GetComponent<AudioSource>().PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}
