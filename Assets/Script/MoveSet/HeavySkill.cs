using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class HeavySkill : MonoBehaviour
{

    [SerializeField] private InputActionReference _emitLighting;
    public UnityEvent OnEmit;

    private void Update()
    {
        if(_emitLighting.action.triggered)
        {
            EmitLight();
        }
    }
    public void EmitLight() => OnEmit.Invoke();
}
