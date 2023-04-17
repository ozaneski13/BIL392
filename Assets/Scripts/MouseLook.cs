using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _player = null;//Rotate ettirecegimiz Player GameObject'inin transformu

    [SerializeField] private float _mouseSensitivty = 100f;//Donus hizi ayari

    private float _xRotation = 0f;//X axisteki rotasyon degeri

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;//Oyun baslayinca farenin gorunup gorunmeyecegini bu satir ile ayarliyorsunuz.
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivty * Time.deltaTime;//Mouse hareket islemi zamana bagli oldugu icin gelen input degeri ile hassaslýk degerini ve gecen zamani carpiyoruz.
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivty * Time.deltaTime;

        _xRotation -= mouseY;//X rotasyonunu Y rotasyonundan ayirmak adina cikartiyoruz.
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);//X rotasyonunun maksimum 90 derece yukari ve 90 derece asagiya bakacak sekilde kisitliyoruz.

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);//Kisitlanan xRotasyonunu Quaterion.Euler ile Cameranin transformuna veriyoruz, ayni kafanizi cevirir gibi.
        _player.Rotate(Vector3.up * mouseX);
    }
}