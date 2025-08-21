using UnityEngine;


public class MagicPerform : SpellManager
{ 
    [SerializeField] private float _burnR;
    [SerializeField] private float _explosionForce;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.instance.PlaySfx(_soundInde);
        var magic = Instantiate(_reactiveMag, transform.position, transform.rotation);
        
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
//var targets = Physics.OverlapSphere(magic.transform.position, _radius);
//foreach (var target in targets)
//{
//    if ((target.CompareTag("Target") || target.CompareTag("Chest")) && target.TryGetComponent<Health>(out var hp))
//    {
//        hp.TakeDamage(_damage);
//    }
//}     