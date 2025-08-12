using UnityEngine;

public class MagicPerform : MonoBehaviour
{
    [SerializeField] private GameObject _performPrefab;
    [SerializeField] private float _burnR;
    [SerializeField] private float _explosionForce;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_performPrefab, transform.position, transform.rotation);
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
