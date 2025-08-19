using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RayCastHit : MonoBehaviour
{
    [SerializeField] private Transform _aimingPos;
    //tam ngam tu man hinh
    [SerializeField] private Transform _chargePos;
    //noi cast phep tao skill
    [SerializeField] private GameObject _effectPref;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private Transform crosshair;
   
    public void Shocking()
    {
        crosshair.gameObject.SetActive(true);
        Ray ray = new(_aimingPos.position, crosshair.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            Instantiate(_effectPref, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
            var targets = Physics.OverlapSphere(rayCasthit.point, _radius);
            foreach (var target in targets)
            {
                if ((target.CompareTag("Target") || target.CompareTag("Chest")) && target.TryGetComponent<Health>(out var hp))
                {
                    hp.TakeDamage(_damage);
                }

            }
            crosshair.gameObject.SetActive(false);
        } 
        
    }
}
