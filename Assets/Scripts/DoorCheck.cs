using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;//Icinden animation state oynatacagimiz Animator'u aliyoruz.

    private void OnTriggerEnter(Collider other)//Kapiya yaklasinca acilma efekti oynamasi gerektiginden Collider triggerlandiginda triggerlayan GameObject Player mi diye kontrol ediyor ve evetse Kapi acma animasyonunu oynatiyoruz.
    {
        if (other.gameObject.tag != "Player")
            return;

        _animator.Play("DoorOpen");//Burada verilen string Animator'deki Animation State'in ismi.
    }

    private void OnTriggerExit(Collider other)//Kapidan uzaklasinca kapanma efekti oynamasi gerektiginden Collider triggerlandiginda triggerlayan GameObject Player mi diye kontrol ediyor ve evetse Kapi kapama animasyonunu oynatiyoruz.
    {
        if (other.gameObject.tag != "Player")
            return;

        _animator.Play("DoorClose");
    }
}