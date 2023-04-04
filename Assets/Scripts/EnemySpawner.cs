using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab = null;//Yaratacagimiz Enemy Prefab'ini SerializeField ile Editor'den aliyoruz.

    [SerializeField] private Transform _enemySpawnPoint = null;//Enemy Prefab'lerinin yaratilicagi noktayi almak icin Editor'den SerializeField ile transform aliyoruz. Siz dilerseniz burada Vector3'de alabilirsiniz ancak her spawn noktasi degistiginde elinizle degerleri degistirmeniz gerekir.

    private void OnTriggerEnter(Collider other)//Collideri triggerlayan karakter ise verilen Prefabi ve spawn noktasini kullanarak Enemy yaratiyoruz.
    {
        if (other.gameObject.tag != "Player")
            return;

        Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
    }

    private void OnDrawGizmos()//Trigger alanimizi gormek adina OnDrawGizmos fonksiyonunu kullanarak ici bos bir kup cizdiriyoruz.
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(GetComponent<BoxCollider>().size.x, GetComponent<BoxCollider>().size.y, GetComponent<BoxCollider>().size.z));
    }
}