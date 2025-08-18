using UnityEngine;
using UnityEngine.AI;
public class targetBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform cheese;
    public LayerMask wIsGround, wIsCheese;
    public Animator _anim;
    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //atk
    public float timeBetweenEat;
    bool ate;
    //states
    public float sightRange, atkRange;
    public bool cheeseInSight, cheeseIsEating;
    private void Awake()
    {
        //find to regconize the cheese
        cheese = GameObject.Find("Cheese").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        cheeseInSight = Physics.CheckSphere(transform.position, sightRange,wIsCheese);
        cheeseIsEating = Physics.CheckSphere(transform.position, atkRange, wIsCheese);
        if (!cheeseInSight && !cheeseIsEating) Patroling();
        if(cheeseInSight) CheeseAtk();
    }
    private void Patroling()
    {
        if (walkPointSet) SearchWalkPoint();
        if(walkPointSet) agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 0.5f) walkPointSet = false;    
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange,walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, wIsGround))
            walkPointSet = true;
    }

    private void CheeseAtk()
    {
        agent.SetDestination(cheese.position);
        transform.LookAt(cheese);
        ate = true;
        _anim.SetBool("isEating", ate);
    }
}
