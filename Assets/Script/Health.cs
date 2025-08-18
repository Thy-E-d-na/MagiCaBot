using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoint;

    //public UnityEvent OnDead;
    public int MaxHealthPoint => _maxHealthPoint;
    public int HealthPoint => _healthPoint;

    private int _healthPoint;

    [SerializeField] private Slider _hpBar;

    private void Start()
    {
        _healthPoint = _maxHealthPoint;
        _hpBar.maxValue = _maxHealthPoint;
        _hpBar.value = _healthPoint;
    }

    public bool IsDead => _healthPoint <= 0;

    public void TakeDamage(int damage)
    {
        if (IsDead) { return; }

        _healthPoint -= damage;
        UpdateHp();
        if (IsDead)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
        GameController.gameinstance.ratDeath();
    }
    private void UpdateHp() => _hpBar.value = _healthPoint;
    
}
