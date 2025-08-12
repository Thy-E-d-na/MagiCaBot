using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CastMagic : MonoBehaviour
{
    [SerializeField] private InputActionReference _cast;
    public UnityEvent OnCast;

    // Update is called once per frame
    void Update()
    {
        if (_cast.action.triggered)
        {
            Cast();
        }
    }
    public void Cast() => OnCast.Invoke();
}
