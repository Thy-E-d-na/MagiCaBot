using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LightSkill : skillManager
{
    //ManualShooting
    [SerializeField] private InputActionReference _shot;
    public UnityEvent OnShot;
    float t;
 
    // Update is called once per frame
    private void OnEnable()
    {
        _shot.action.started += Charge;
        _shot.action.canceled += Cast;
        _shot.action.Enable();
    }
    private void OnDisable()
    {
        _shot.action.started -= Charge;
        _shot.action.canceled -= Cast;
        _shot.action.Disable();
    }
    void Charge(InputAction.CallbackContext context) => t = Time.time;

    void Cast(InputAction.CallbackContext context)
    {
        if ((Time.time - t) <= 1)
        {
            Shot();
        }
    }
   
    public void Shot() => OnShot.Invoke();
}
