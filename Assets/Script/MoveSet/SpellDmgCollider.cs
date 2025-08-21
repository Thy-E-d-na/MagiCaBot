using UnityEngine;

public class SpellDmgCollider : MonoBehaviour
{
    [SerializeField] private int dmg;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            other.TryGetComponent<Health>(out var hp);
            hp.TakeDamage(dmg);
        }
    }
}
