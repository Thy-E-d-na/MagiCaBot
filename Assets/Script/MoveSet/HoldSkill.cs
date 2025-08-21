using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HoldSkill : SpellManager
{
    //Electric skills
    [SerializeField] private InputActionReference _charge;
    [SerializeField] private Transform chargePos;

    GameObject mag;
    float t;

    //public UnityEvent Oncast;

    public bool isCharging;

    private void OnEnable()
    {
        _charge.action.started += StartCharge;
        _charge.action.canceled += EndCharge;
        _charge.action.Enable();
    }
    private void OnDisable()
    {
        _charge.action.started -= StartCharge;
        _charge.action.canceled -= EndCharge;
        _charge.action.Disable();
    }
    
    void StartCharge(InputAction.CallbackContext context)
    {
        isCharging = true;
        mag = Instantiate(_chargeSpell,chargePos);
        t = Time.time;
    }
    void EndCharge(InputAction.CallbackContext context)
    {
        isCharging = false;
        if((Time.time - t) >= 2)
        { 
            Shocking();            
        }
        Destroy(mag.gameObject);
    }

    [Header("RayCastHit")]

    [SerializeField] private Transform _aimingPos;
    [SerializeField] private float _radius;
    public void Shocking()
    {
        
        Ray ray = new(_aimingPos.position, chargePos.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            SoundManager.instance.PlaySfx(_soundInde);
            Instantiate(_reactiveMag, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
            
        }

    }
    //public void Casting() => Oncast.Invoke();


}
