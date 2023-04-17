using UnityEngine;
using UnityEngine.UI;

public class DummyHit : MonoBehaviour
{
    [SerializeField] private Gradient _gradient = null;
    [SerializeField] private Image _image = null;
    [SerializeField] private Slider _slider = null;

    private float _health = 100;//Dummy'nin baslangic can degeri.
    private float _currentHealth = 0;

    private bool _isDead = false;//Olu olma durumunu tutan bool.

    private void Awake()
    {
        _currentHealth = _health;
        _slider.maxValue = _currentHealth;
        _slider.value = _currentHealth;
        _image.color = _gradient.Evaluate(1f);
    }

    private void OnCollisionEnter(Collision collision)//Mermi  carptiginda carpan GameObject'in mermi olup olmadiginin kontrolunu yaptiktan ve olu olma durumunu kontrol ettikten sonra cani 50 azaltiyoruz.
    {
        if (collision.gameObject.tag == "Bullet" && !_isDead)
        {
            _currentHealth -= 20;
            _image.color = _gradient.Evaluate(_currentHealth / _health);
            _slider.value = _currentHealth;

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