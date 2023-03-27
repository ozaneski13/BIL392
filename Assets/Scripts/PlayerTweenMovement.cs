using DG.Tweening;
using UnityEngine;

public class PlayerTweenMovement : MonoBehaviour
{
    [SerializeField] private float _destination = 0f;
    [SerializeField] private float _duration = 2f;
    [SerializeField] private bool _snapping = false;

    private void Start()
    {
        transform.DOMoveZ(_destination, _duration, _snapping);
    }
}