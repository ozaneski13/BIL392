using UnityEngine;
using DG.Tweening;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 1f;//Enemy'nin rotasyon suresi degeri.
    [SerializeField] private float _moveDuration = 50f;//Yeni hedefi belirlemeden yolu alacagi sure.

    private Transform _player = null;//Takip edecegi Player transformu.

    private void Start()
    {
        _player = Player.Instance.transform;//Singleton uzerinden alinan Player transformu.

        transform.DOLookAt(_player.transform.position - transform.position, _rotationDuration, AxisConstraint.X).OnComplete(() => StartCoroutine(StartRun()));//DOTween'in DoLookAt ile verdigimiz yone bakmasini sagliyoruz. Boylece one dogru hareket ederken surekli baktigi yone gidecek ve Player'i kovalayacak.
    }

    private IEnumerator StartRun()//Bu Coroutine DoLookAt fonksiyonunun OnComplete eventinde cagriliyor. Boylece rotasyon islemi bittiginde dongu icerisinde Player'i takip edebiliyor.
    {
        while(true)
        {
            float playerZPosition = _player.position.z;

            transform.DOMoveZ(playerZPosition, _moveDuration);

            yield return new WaitForSeconds(_moveDuration);
        }
    }
}