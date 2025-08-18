using UnityEngine;

public class spawnScript : MonoBehaviour
{
    [SerializeField] private GameObject _rat;
    [SerializeField] private float _rate;
    private void Start()
    {
        InvokeRepeating(nameof(Spawning), 3f, _rate);
    }
    private void Spawning()
    {
        var rat = Instantiate(_rat, transform.position, Quaternion.identity);

    }
    public void stopSpawning()
    {
        CancelInvoke(nameof(Spawning));
    }
    public void startSpawning()
    {
        InvokeRepeating(nameof(Spawning), 3f, _rate);
    }
}
