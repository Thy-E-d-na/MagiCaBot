using UnityEngine;

public class RotateStaff : MonoBehaviour
{
    
    [SerializeField] private Transform _1Ring;
    [SerializeField] private Transform _outRing;
    [SerializeField] private Transform _2Ring;
    [SerializeField] float rotateSpeed;


    // Update is called once per frame
    void Update()
    {
        _1Ring.Rotate(Vector3.right * rotateSpeed);
        _2Ring.Rotate(Vector3.up * -rotateSpeed);
        _outRing.Rotate(Vector3.forward * rotateSpeed);
    }
}
