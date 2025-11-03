using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShieldBehaviour : MonoBehaviour, IBlockDelayDebuffable, IBlockEfficiencyDebuffable, IBlockTimeDebuffable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerMovementBrain _movementBrain;
    [SerializeField] private float _shieldDelay;
    [SerializeField] private float _shieldBlockEfficiency;
    [SerializeField] private float _shieldBlockTime;
    [SerializeField] public UnityEvent OnShieldPerform;
    public IEnumerator ApplyShield()
    {
        _animator.SetFloat("shieldSpeed", 1 / _shieldDelay);
        _animator.SetBool("shield", true);
        _movementBrain.Freeze = true;
        yield return new WaitForSeconds(_shieldDelay);
        _playerHealth.DamageModifier = 1 - _shieldBlockEfficiency;
        OnShieldPerform?.Invoke();
        yield return new WaitForSeconds(_shieldBlockTime);
        _playerHealth.DamageModifier = 1;
        _movementBrain.Freeze = false;
        _animator.SetBool("shield", false);
    }

    public void DebuffBlockDelay(float modifier)
    {
        _shieldDelay *= _shieldDelay * (1 + modifier);
    }

    public void DebuffBlockEfficiency(float modifier)
    {
        _shieldBlockEfficiency *= _shieldBlockEfficiency * (1 - modifier);
    }

    public void DebuffBlockTime(float modifier)
    {
        _shieldBlockTime *= _shieldBlockTime * (1 - modifier);
    }
}
