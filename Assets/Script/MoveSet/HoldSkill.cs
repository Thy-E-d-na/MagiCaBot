using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HoldSkill : MonoBehaviour
{
    //Electric skills
    [SerializeField] private InputActionReference _charge;
    [SerializeField] private GameObject _skillVfx;
    [SerializeField] Slider _skillChargeSlider;
    [SerializeField] private Transform chargePos;
    GameObject mag;

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
        _skillChargeSlider.gameObject.SetActive(true);
    }
    void EndCharge(InputAction.CallbackContext context)
    {
        isCharging = false;
        Destroy(mag.gameObject);
        _skillChargeSlider.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isCharging && _skillChargeSlider.enabled)
        {
            float t = Time.time;
            _skillChargeSlider.value = t;
        }

    }

}
