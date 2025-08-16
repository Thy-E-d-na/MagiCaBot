using UnityEngine;

public class boxDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _destroyEffect;
    public void unBox()
    {
        var openBox = Instantiate(_destroyEffect,transform.position,Quaternion.identity);
        Destroy(_box);

    }
    
}
