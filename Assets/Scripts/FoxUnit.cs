using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class FoxUnit : MonoBehaviour
{
    Animator animator;
    public NavMeshAgent Agent;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // reached to destination
        //(!Agent.pathPending && !Agent.hasPath)
        if (Agent.hasPath)
        {
            animator.SetBool("Walk", true);
            Debug.Log("Walk = true");
        }
        else
        {
            animator.SetBool("Walk", false);
            Debug.Log("Walk = false");
        }
         
    }


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        FoxManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }
}