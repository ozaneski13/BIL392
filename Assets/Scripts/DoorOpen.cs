using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private AudioSource _source = null;
    public void PlaySound()
    {
        _source.Play();
    }
}