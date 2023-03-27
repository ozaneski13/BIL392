using UnityEngine;
using DG.Tweening;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 1f;
    [SerializeField] private float _moveDuration = 50f;

    private Transform _player = null;

    private void Start()
    {
        _player = Player.Instance.transform;

        transform.DOLookAt(_player.transform.position - transform.position, _rotationDuration, AxisConstraint.X).OnComplete(() => StartCoroutine(StartRun()));
    }

    private IEnumerator StartRun()
    {
        while(true)
        {
            float playerZPosition = _player.position.z;

            transform.DOMoveZ(playerZPosition, _moveDuration);

            yield return new WaitForSeconds(_moveDuration);
        }
    }
}