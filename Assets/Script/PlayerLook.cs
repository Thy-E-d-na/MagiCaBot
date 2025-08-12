using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private InputActionReference _plLook;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private Transform _camHolder;
    float _pitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pitch = _camHolder.transform.localEulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        var input = _plLook.action.ReadValue<Vector2>();
        UpdatePitch(input.y);
        UpdateYaw(input.x);

    }

    private void UpdatePitch(float inputY)
    {
        var pitch = -inputY * _rotateSpeed * Time.deltaTime;
        //trục Y dương thường ngược chiều Camera
        _pitch = Mathf.Clamp(_pitch + pitch, _minPitch, _maxPitch);
        _camHolder.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

    private void UpdateYaw(float inputX)
    {
        var yaw = inputX * _rotateSpeed * Time.deltaTime;
        transform.Rotate(0, yaw, 0);
    }
}
