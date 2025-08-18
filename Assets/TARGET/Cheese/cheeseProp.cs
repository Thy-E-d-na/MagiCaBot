using UnityEngine;

public class cheeseProp : MonoBehaviour
{
    private Health cheeseHp;
    private void Start()
    {
        cheeseHp = GetComponent<Health>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        { 
            cheeseHp.TakeDamage(10);
        }              
    }
    private void Update()
    {
        if(cheeseHp.HealthPoint <= 0)
        {
            GameController.gameinstance.gameLose();
        }
    }
}
