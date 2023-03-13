using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform _player = null;

    [SerializeField] private float _mouseSensitivty = 100f;

    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivty * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivty * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _player.Rotate(Vector3.up * mouseX);
    }
}