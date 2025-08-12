using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class LightSkill : skillManager
{
    //ManualShooting
    [SerializeField] private InputActionReference _shot;
    public UnityEvent OnShot;
  
    // Update is called once per frame
    void Update()
    {
        if(_shot.action.triggered)
        {
            Shot();
        }
    }
    public void Shot() => OnShot.Invoke();
}
