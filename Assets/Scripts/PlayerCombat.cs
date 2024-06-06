using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private BaseWeapon[] startingWeapons;
    [SerializeField] private MeeleeWeapon meleWeapon;
    [SerializeField] private HitScanWeapon hitScanWeapon;

    private BaseWeapon currentWeapon;

    private void Start()
    {
        currentWeapon = meleWeapon;
    }

    private void OnAttack()
    {
        currentWeapon.Fire();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if (currentWeapon.isAttacking == false)
            {
                WeaponSwap(0);
            } 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            if (currentWeapon.isAttacking == false)
            {
                WeaponSwap(1);
            }
        } 
        
        if (Input.GetMouseButtonDown(0)) OnAttack();
    }

    private void WeaponSwap(int BaseWeapon)
    {
       for (int i = 0; i < startingWeapons.Length; i++ )
       {
            Debug.Log(i);
            if(BaseWeapon == i)
            {
                startingWeapons[i].gameObject.SetActive(true);
                currentWeapon = startingWeapons[i];
            }
            else
            {
                startingWeapons[i].gameObject.SetActive(false);
            }
       }
    }
}
