using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;

public class AOE_sword : MonoBehaviour
{
    //Automatic Shoot
    [SerializeField] private InputActionReference _charge;
    [SerializeField] private GameObject _skillVfx;
    [SerializeField] Slider _skillChargeSlider;
    public UnityEvent OnCast;
    private void Update()
    {
        if(_charge.action.triggered)
        {
            _skillChargeSlider.gameObject.SetActive(true);
            Cast();
        }
    }
    public void Cast()
    {
        OnCast?.Invoke();
        _skillChargeSlider.gameObject.SetActive(false);
    }

}
