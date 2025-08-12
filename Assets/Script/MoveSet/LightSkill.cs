using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LightSkill : skillManager
{
    //ManualShooting
    [SerializeField] private InputActionReference _fire;
    public UnityEvent OnFire;
  
    // Update is called once per frame
    void Update()
    {
        if(_fire.action.triggered)
        {
            Fire();
        }
    }
    public void Fire() => OnFire.Invoke();
}
