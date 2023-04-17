using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TextMeshPro;
    private float _timer = 60f;

    private void Update()
    {
        _timer -= Time.deltaTime;
        _TextMeshPro.text = _timer.ToString();
    }
}