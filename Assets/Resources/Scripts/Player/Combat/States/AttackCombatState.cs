using System.Collections;
using UnityEngine;

public class AttackCombatState : IState
{
    private AttackPoint _attackPoint;
    private float _damage;
    private float _delay;
    private float _cooldown;
    private float _timestamp;

    private IEnumerator _attackCoroutine;

    public AttackCombatState(AttackPoint attackPoint, float delay, float cooldown, float damage)
    {
        _attackPoint = attackPoint;
        _delay = delay;
        _cooldown = cooldown;
        _damage = damage;
    }

    public void OnEnter()
    {
        _attackCoroutine = PerformAttack();
        _attackPoint.StartCoroutine(_attackCoroutine);
    }

    public void OnExit()
    { }

    public void Tick()
    { }

    public bool IsDone() => _attackCoroutine == null;

    private IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(_delay);

        Collider[] colliders = Physics.OverlapSphere(_attackPoint.transform.position, _attackPoint.Radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out IDamagable damagable) && collider.TryGetComponent(out Player player) == false)
            {
                Debug.Log($"Damage to {collider.name}");
                damagable.TakeDamage(_damage);
            }
        }

        yield return new WaitForSeconds(_cooldown);

        _attackCoroutine = null;
    }
}