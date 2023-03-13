using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private Transform _firePoint = null;

    [SerializeField] private Transform _parent = null;

    [SerializeField] private float _bulletSpeed = 100f;
    [SerializeField] private float _timeToInactive = 2f;

    [SerializeField] private int _poolSize = 100;

    [SerializeField] private float _rayDistance = 200f;

    private List<GameObject> _bulletPool = null;

    private void Awake()
    {
        FillPool();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            Fire();
    }

    private void FillPool()
    {
        _bulletPool = new List<GameObject>();

        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity, _parent);
            bullet.SetActive(false);

            _bulletPool.Add(bullet);
        }
    }

    private void Fire()
    {
        StartCoroutine(FireRoutine());
    }

    private IEnumerator FireRoutine()
    {
        GameObject bulletToFire = _bulletPool[_bulletPool.Count - 1];
        _bulletPool.Remove(bulletToFire);

        bulletToFire.transform.position = _firePoint.position;
        bulletToFire.SetActive(true);
        bulletToFire.GetComponent<Rigidbody>().AddForce(_firePoint.forward * _bulletSpeed);

        yield return new WaitForSeconds(_timeToInactive);

        bulletToFire.SetActive(false);
        _bulletPool.Add(bulletToFire);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_firePoint.position, _firePoint.forward * _rayDistance);
    }
}