using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private AudioSource _source = null;//Animation uzerinden oynatacagimiz ses kaynagini tutuyoruz.
    public void PlaySound()//Public yapmamizin sebebi Animation Event'inin fonksiyona ulasabilmesi.
    {
        _source.Play();//Sesi caliyoruz.
    }
}