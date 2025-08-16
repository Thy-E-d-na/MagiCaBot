using UnityEngine;

public class RayCastHit : MonoBehaviour
{
    [SerializeField] private Transform _aimingPos;
    //tam ngam tu man hinh
    [SerializeField] private Transform _chargePos;
    //noi cast phep tao skill
    [SerializeField] private GameObject _effectPref;
    public void Shocking()
    {
        Ray ray = new(_aimingPos.position, _chargePos.position - _aimingPos.position);
        if (Physics.Raycast(ray, out var rayCasthit))
        {
            Instantiate(_effectPref, rayCasthit.point, Quaternion.LookRotation(rayCasthit.normal));
        }
    }
}
