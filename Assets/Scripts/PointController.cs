using UnityEngine;

public class PointController : MonoBehaviour
{
    public static PointController Instance;//Singleton haline getirmek icin PointController'in instance degiskenini olusturuyoruz.
    private void Awake()//Awake ilk cagrilacak fonksiyon oldugu icin fonksiyonun icinde bu scripti instance olarak tanimliyoruz.
    {
        if(Instance == null)//instance yoksa yeni instance bu kod.
            Instance = this;

        if (Instance != null && Instance != this)//instance varsa ve bu kod degilse bu kodu yok et.
            Destroy(Instance);
    }

    private int _pointCount = 0;//Gelen puanlari tutuyoruz.

    public void UpdatePoint(int point)//Singleton uzerinden bu fonksiyona erisen diger scriptler bu fonksiyon ile puan degerini arttirabiliyor.
    {
        _pointCount += point;
    }
}