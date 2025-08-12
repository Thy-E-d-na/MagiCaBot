using UnityEngine;

public class FireBurn : MonoBehaviour
{
    //grenade
    [SerializeField] private GameObject _burnPrefab;
    [SerializeField] private float _burnR;
    [SerializeField] private float _explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_burnPrefab, transform.position, transform.rotation);
        PushNearbyObjects();
        Destroy(gameObject);
    }

    private void PushNearbyObjects()
    {
        var victims = Physics.OverlapSphere(transform.position, _burnR);
        foreach (var victim in victims)
        {
            if (victim.TryGetComponent<Rigidbody>(out var rigid))
            {
                rigid.AddExplosionForce(_explosionForce, transform.position, _burnR,
                    1f, ForceMode.Impulse);
            }

            if (victim.TryGetComponent<ExploitableCube>(out var cube))
            {
                cube.Explode(_explosionForce, transform.position, _burnR);
            }
        }
    }
}
