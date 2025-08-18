using UnityEngine;


public class MagicPerform : MonoBehaviour
{
    [SerializeField] private GameObject _performPrefab;
    [SerializeField] private float _burnR;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
   
    private void OnTriggerEnter(Collider other)
    {
        var magic = Instantiate(_performPrefab, transform.position, transform.rotation);
        var targets = Physics.OverlapSphere(magic.transform.position, _radius);
        foreach (var target in targets)
        {
            if ((target.CompareTag("Target") || target.CompareTag("Chest")) && target.TryGetComponent<Health>(out var hp))
            {
                hp.TakeDamage(_damage);
            }
        }     
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
