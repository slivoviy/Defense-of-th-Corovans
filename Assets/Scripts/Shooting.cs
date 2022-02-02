using System;
using System.Collections;
using Scriptable_Objects;
using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Weapon weapon;

    private bool _isReloading;
    private int _ammoAmount;
    private float _timeToReload;
    private float _bulletForce;

    private void Start() {
        _bulletForce = weapon.bulletForce;
        _ammoAmount = weapon.ammoQuantity;
        _timeToReload = weapon.timeToReload;
        _bulletForce = weapon.bulletForce;
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (!_isReloading) {
                Shoot();
            }
        }

        if (_ammoAmount == 0) {
            StartCoroutine(Reload());
        }
    }

    private void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * _bulletForce, ForceMode2D.Impulse);
        _ammoAmount--;
    }

    private IEnumerator Reload() {
        _isReloading = true;
        
        yield return new WaitForSeconds(_timeToReload);

        _ammoAmount = weapon.ammoQuantity;
        _isReloading = false;
    }
}