using UnityEngine;

public class DummyHit : MonoBehaviour
{
    private int _health = 100;//Dummy'nin baslangic can degeri.

    private bool _isDead = false;//Olu olma durumunu tutan bool.

    private void OnCollisionEnter(Collision collision)//Mermi  carptiginda carpan GameObject'in mermi olup olmadiginin kontrolunu yaptiktan ve olu olma durumunu kontrol ettikten sonra cani 50 azaltiyoruz.
    {
        if (collision.gameObject.tag == "Bullet" && !_isDead)
        {
            _health -= 50;

            if (_health <= 0)
            {
                _isDead = true;
                Debug.Log("Dummy died.");//Console'a Dummy'nin oldugunu basiyoruz.
                PointController.Instance.UpdatePoint(100);//PointController'a Singleton uzerinden ulasip kazandigimiz puan miktarini yolluyoruz.

                return;
            }

            PointController.Instance.UpdatePoint(10);
        }
    }
}