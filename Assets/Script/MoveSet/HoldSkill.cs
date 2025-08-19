using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class HoldSkill : MonoBehaviour
{
    //Electric skills
    [SerializeField] private InputActionReference _charge;
    [SerializeField] private GameObject _skillVfx;
    [SerializeField] private Transform chargePos;
    GameObject mag;
 
    [SerializeField] private Transform _aimingPos;
    //tam ngam tu man hinh
    [SerializeField] private Transform _chargePos;
    //noi cast phep tao skill
    [SerializeField] private GameObject _effectPref;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private Transform crosshair;

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
        mag = Instantiate(_skillVfx, chargePos.position, chargePos.rotation,chargePos);
        crosshair.gameObject.SetActive(true);
    }
    void EndCharge(InputAction.CallbackContext context)
    {
        isCharging = false;
        Shocking();
        crosshair.gameObject.SetActive(false);
        Destroy(mag.gameObject);
       
    }
   

    public void Shocking()
    {
        
        Ray ray = new(_aimingPos.position, crosshair.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            Instantiate(_effectPref, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
            var targets = Physics.OverlapSphere(rayCasthit.point, _radius);
            foreach (var target in targets)
            {
                if ((target.CompareTag("Target") || target.CompareTag("Chest")) && target.TryGetComponent<Health>(out var hp))
                {
                    hp.TakeDamage(_damage);
                }

            }
            
        }

    }

}
