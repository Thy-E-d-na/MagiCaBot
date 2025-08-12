using UnityEngine;
using UnityEngine.InputSystem;


public class Charging : MonoBehaviour
{
    // Chargeskill launcher
    [SerializeField] private Rigidbody _skillPrefab;
    [SerializeField] private Transform _castPos;
    [SerializeField] private float _approachSpeed;

    public void Casting()
    {
        var cast = Instantiate(_skillPrefab, _castPos.position, _castPos.rotation);
        cast.linearVelocity = _castPos.forward * _approachSpeed;
        Destroy(cast.gameObject, 10f);
    }
}
