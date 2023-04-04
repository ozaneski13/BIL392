using DG.Tweening;
using UnityEngine;

public class PlayerTweenMovement : MonoBehaviour
{
    [SerializeField] private float _destination = 0f;//Tween ile DoMoveZ islemi yaptigimiz icin sadece varis noktasinin z degerine ihtiyacimiz var. Bu yuzden Vector3 degil float tutabiliyoruz.
    [SerializeField] private float _duration = 2f;//Kac saniyede varis noktasina ulasacagi.
    [SerializeField] private bool _snapping = false;//Snapping ilerleme isleminin smooth bir sekilde yapilip yapilmayacagini kontrol ediyor.

    private void Start()
    {
        transform.DOMoveZ(_destination, _duration, _snapping);
    }
}