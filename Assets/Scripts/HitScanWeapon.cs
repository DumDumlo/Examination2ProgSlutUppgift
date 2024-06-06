using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeapon : BaseWeapon
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem MuzzleFlash;
    [SerializeField] private Transform pipe;
    bool isUsing;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public override void Fire()
    {
        Shoot();
        Instantiate(MuzzleFlash, pipe.position, Quaternion.identity);
    }

    private void Shoot()
    {
        Vector3 targetDir = Camera.main.transform.forward;

        bool didHit = Physics.Raycast(firePoint.position, targetDir, out RaycastHit hit);
        if (!didHit) return;

        bool foundDamageable = hit.collider.gameObject.TryGetComponent(out Damageable damageHit);
        if (!foundDamageable) return;

        DamageInfo info = new DamageInfo()
        {
            damage = this.damage,
            weapon = this,
            distance = hit.distance
        };
        damageHit.TakeDamage(info);
    }
}
