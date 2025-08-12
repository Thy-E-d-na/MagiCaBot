using UnityEngine;

public class PyroCast : MonoBehaviour
{

    // Grenadelauncher
    [SerializeField] private Rigidbody _fireBallPrefab;
    [SerializeField] private Transform _firingPos;
    [SerializeField] private float _approachSpeed;

    public void Casting()
    {
        var fire = Instantiate(_fireBallPrefab, _firingPos.position, _firingPos.rotation);
        fire.linearVelocity = _firingPos.forward * _approachSpeed;
        Destroy(fire.gameObject, 10f);
    }
}
