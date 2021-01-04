using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float damage = 25;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType _ammoType;
    [SerializeField] float _timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI _ammoText;
    

    bool _canShoot = true;

    void OnEnable()
    {
        _canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1") && _canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(_ammoType);
        _ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        _canShoot = false;
        if (ammoSlot.GetCurrentAmmo(_ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(_ammoType);
        }
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, _range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
