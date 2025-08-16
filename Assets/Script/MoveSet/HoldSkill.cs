using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldSkill : MonoBehaviour
{
    //Electric skills
    [SerializeField] private InputActionReference _charge;
    [SerializeField] private GameObject _skillVfx;
    [SerializeField] private Transform chargePos;
    GameObject mag;

    [SerializeField] private InputActionReference _emitLighting;
    public UnityEvent OnEmit;
    public void EmitLight() => OnEmit.Invoke();

    public bool isCharging;
    public float chargingtime;

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
        mag = Instantiate(_skillVfx, chargePos);
       
    }
    void EndCharge(InputAction.CallbackContext context)
    {
        isCharging = false;
        Destroy(mag.gameObject);
       
    }
    private void Update()
    {
        if (isCharging)
        {
            float t = Time.time;
            
            EmitLight();
        }

    }

}
