using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController = null;

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpHeight = 3f;
    [SerializeField] private float _gravity = -9.81f;

    [SerializeField] private Transform _groundCheck = null;
    [SerializeField] private float _groundDistance = 0.1f;

    [SerializeField] private LayerMask _layer;

    private Vector3 _velocity = Vector3.zero;

    private bool _isGrounded = true;

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _layer);

        if (_isGrounded && _velocity.y < 0)
            _velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _characterController.Move(move * Time.deltaTime *_moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

        _velocity.y += _gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}