using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class CameraBlock : MonoBehaviour
{
    [SerializeField] private Transform _cam;
    [SerializeField] private float _r;
    [SerializeField] private LayerMask _hitMask;    //chi kiểm tra va chạm vs các layer thuojc layerMask này
    float _camMaxDistance;
    
    void Start() => _camMaxDistance = Mathf.Abs(_cam.localPosition.z);
    //lưu khoảng cách từ sau lưng player đến cam

   
    void Update()
    {
        var direction = -transform.forward; //hướng nhìn phía sau player
        Ray lookingRay = new(transform.position, direction); // tia nhìn vè phía sau theo direction 
        //if (Physics.SphereCast(lookingRay, _r, out var hit, _camMaxDistance, _hitMask)) >> có thể dùng Ray dể debug
        if (Physics.SphereCast(transform.position, _r, direction, out var hit, _camMaxDistance, _hitMask))
        {
            _cam.localPosition = hit.point;
        }
        else
        {
            _cam.localPosition = new(0,0,_camMaxDistance);
        }
    }
}
