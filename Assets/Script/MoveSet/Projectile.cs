using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Grenadelauncher
    [SerializeField] private Rigidbody _elementPrefab;
    [SerializeField] private Transform _firingPos;
    [SerializeField] private float _approachSpeed;

    public void Casting()
    {
        var elem = Instantiate(_elementPrefab, _firingPos.position, _firingPos.rotation);
        elem.linearVelocity = _firingPos.forward * _approachSpeed;
        Destroy(elem.gameObject, 10f);
    }
}
