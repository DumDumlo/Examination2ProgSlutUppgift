using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MeeleeWeapon : BaseWeapon
{
    [SerializeField] private TriggerListener[] triggers;
    [SerializeField] private float attackDuration;
    [SerializeField] private Animator animator;

    public override void Fire()
    {
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        isAttacking = true;
        float currentDuration = 0.0f;

        animator.SetTrigger("meleeSwing");

        var hasHit = new List<Damageable>();


        while (currentDuration < attackDuration)
        {
            Damage(hasHit);
            yield return new WaitForFixedUpdate();
            currentDuration += Time.fixedDeltaTime;
        }

        isAttacking = false;
    }

    private void Damage(List<Damageable> hasHit)
    {
        var hits = new List<Collider>();
        foreach (var trigger in triggers)
        {
            hits.AddRange(trigger.CollidersInMe);
        }

        foreach(var hit in hits)
        {
            if (!hit.gameObject.TryGetComponent(out Damageable damageable)) continue;
            if (hasHit.Contains(damageable)) continue;

            hasHit.Add(damageable);
            damageable.TakeDamage(new DamageInfo()
            {
                damage = damage,
                distance = 0,
                weapon = this
            });
        }
    }
}
