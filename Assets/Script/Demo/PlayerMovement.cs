using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _moveInput;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private InputActionReference _jump;
    [SerializeField] private float _jumpForce;
        private float _velocityY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var input = _moveInput.action.ReadValue<Vector2>();
        var direction = transform.forward * input.y + transform.right * input.x;
        var velocity = direction * _moveSpeed;
        if(_jump.action.triggered && _characterController.isGrounded)
        {
            _velocityY = _jumpForce;
        }
        else
        {
            UpdateFall();
        }
        velocity.y = _velocityY;
        _characterController.Move(velocity * Time.deltaTime);

    }

    private void UpdateFall()
    {
        if (_characterController.isGrounded)
        {
            _velocityY = -1;
        }
        else
        {
            _velocityY += Physics.gravity.y * Time.deltaTime;
        }
    }
}
