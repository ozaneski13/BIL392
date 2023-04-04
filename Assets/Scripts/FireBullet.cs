using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bullet = null;//Pool olusturacagimiz mermi prefabi
    [SerializeField] private Transform _firePoint = null;//Mermilerin namluda ateslenecegi noktayi alacagimiz transform

    [SerializeField] private Transform _parent = null;//Yaratilacak mermilerin tutulacagi parent GameObject

    [SerializeField] private float _bulletSpeed = 100f;//Merminin namludan cikarken alacagi ilk hiz degeri
    [SerializeField] private float _timeToInactive = 2f;//Ateslenen mermi belli bir sure boyunca hit olmazsa inaktif hale geciyor

    [SerializeField] private int _poolSize = 100;//Olusturulacak havuzun buyuklugu

    [SerializeField] private float _rayDistance = 200f;//Debug icin kullanacagimiz Gizmosun cizecegi dogrunun ulasacagi en uzak nokta

    private List<GameObject> _bulletPool = null;

    private void Awake()
    {
        FillPool();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))//Sag click yapildiginda ates ediyoruz.
            Fire();
    }

    private void FillPool()
    {
        _bulletPool = new List<GameObject>();//Poolu initialize ediyoruz

        for (int i = 0; i < _poolSize; i++)//Belirlenen pool buyuklugu kadar mermi yaratilip kullanýlacagi zamana kadar inaktif hale getiriliyor
        {
            GameObject bullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity, _parent);
            bullet.SetActive(false);

            _bulletPool.Add(bullet);
        }
    }

    private void Fire()
    {
        StartCoroutine(FireRoutine());//Her ates edildiginde farkli bir Coroutine baslatiyoruz boylece her memi icin ayri inaktif olma suresi olcebiliyoruz.
    }

    private IEnumerator FireRoutine()
    {
        GameObject bulletToFire = _bulletPool[_bulletPool.Count - 1];//Pool listesindeki son elemani aliyoruz.
        _bulletPool.Remove(bulletToFire);//GameObject'i listeden cikartiyoruz ki pespese yapilabilecek ates etme islemleri hali hazirda kullanilan mermileri etkilemesin.

        bulletToFire.transform.position = _firePoint.position;//Merminin baslangic pozisyonunu namlunun ucu olacak sekilde degistirip aktif ediyoruz.
        bulletToFire.SetActive(true);
        bulletToFire.GetComponent<Rigidbody>().AddForce(_firePoint.forward * _bulletSpeed);//Merminin Rigidbody componentina ulasip Force veriyoruz.

        yield return new WaitForSeconds(_timeToInactive);//Mermi hareket ederken belli bir sure carpisacak mi diye bekliyoruz. Eger carpismazsa inaktif hale getirip havuza geri ekliyoruz.

        bulletToFire.SetActive(false);
        _bulletPool.Add(bulletToFire);
    }

    private void OnDrawGizmos()//Merminin ateslenecegi noktaya göre izleyecegi yolu gormek icin ray cizdiriyoruz.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_firePoint.position, _firePoint.forward * _rayDistance);
    }
}