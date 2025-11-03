using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public static PlayerSound Instance;

    public AudioSource audioSource;
    public AudioClip[] footstepClips;
    public AudioClip[] attackClips;
    public AudioClip[] hitClips;

    [Header("Cooldowns")]
    public float footstepCooldown = 0.35f;
    public float attackCooldown = 0.2f;

    private Rigidbody2D rb;
    private float lastFootstepTime = -Mathf.Infinity;
    private float lastAttackTime = -Mathf.Infinity;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        if (rb == null || footstepClips.Length == 0) return;

        if (rb.linearVelocity.sqrMagnitude > 0.05f && Time.time - lastFootstepTime >= footstepCooldown)
        {
            PlayRandom(footstepClips);
            lastFootstepTime = Time.time;
        }
    }

    // игрок ударил, не попал
    public void PlayAttackSound()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayRandom(attackClips);
            lastAttackTime = Time.time;
        }
    }

    //  игрок ударил, попал
    public void PlayHitSound()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayRandom(hitClips);
            lastAttackTime = Time.time;
        }
    }


    private void PlayRandom(AudioClip[] clips)
    {
        if (clips.Length == 0 || audioSource == null) return;
        audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }
}
