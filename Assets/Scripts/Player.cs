using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;//PointController'da yaptigimiz Singleton isleminin aynisi. Tek fark orada scripti yok ederken burada Player scriptinin parenti olan GameObject'i yok ediyoruz.

    private void Awake()
    {
        if(Instance == null) 
        {
            Instance = this;
        }

        if(Instance != null && Instance != this) 
        { 
            Destroy(gameObject);
        }
    }
}