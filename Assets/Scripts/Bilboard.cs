using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    [SerializeField] private Transform _camera = null;

    void Update()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
}