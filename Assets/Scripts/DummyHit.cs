using UnityEngine;

public class DummyHit : MonoBehaviour
{
    private int _health = 100;

    private bool _isDead = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !_isDead)
        {
            _health -= 50;

            if (_health <= 0)
            {
                _isDead = true;
                Debug.Log("Dummy died.");
                PointController.Instance.UpdatePoint(100);

                return;
            }

            PointController.Instance.UpdatePoint(10);
        }
    }
}