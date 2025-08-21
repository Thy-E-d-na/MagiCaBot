using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RayCastHit : SpellManager
{
    [SerializeField] private Transform _aimingPos;
    [SerializeField] private int _damage;
    [SerializeField] private float _radius;
    [SerializeField] private Transform _spawmPos;
   
    public void Shocking()
    {

        Ray ray = new(_aimingPos.position, _spawmPos.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            Instantiate(_reactiveMag, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
            
        } 
        
    }
}
