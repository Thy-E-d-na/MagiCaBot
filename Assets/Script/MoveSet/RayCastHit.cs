using UnityEngine;

public class RayCastHit : MonoBehaviour
{
    [SerializeField] private Transform _aimingPos;
    [SerializeField] private Transform _charge;
    //[SerializeField] private GameObject _HitArea;
    [SerializeField] private GameObject _effectPref;
    public void Shocking()
    {
        Ray ray = new(_aimingPos.position, _charge.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            //Instantiate(_effectPref, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
            Instantiate(_effectPref, rayCasthit.point, Quaternion.identity);
        }
    }
}
