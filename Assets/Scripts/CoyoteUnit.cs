using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class CoyoteUnit : MonoBehaviour
{
    //Animator animator;
    public NavMeshAgent Agent;
    private Transform Target;
    public LightingManager _LM;
    private int destPoint = 0;
    [SerializeField]
    private GameObject List;
    [SerializeField]
    private GameObject Carcasses;



    private void Start()
    {
        StartCoroutine(MoveCoyote());
    }


    IEnumerator MoveCoyote()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(1);

            if (_LM.getTimeOfDay() == (int)(5 * 13))
            {
                GotoNextPoint();
            }
            else if (_LM.getTimeOfDay() == (int)(7 * 13))
            {
                GotoNextPoint();
            }
            else if (_LM.getTimeOfDay() == (int)(18 * 13))
            {
                GotoNextPoint();
            }
            else if (_LM.getTimeOfDay() == (int)(20 * 13))
            {
                int randomTarget = Random.Range(0, Carcasses.transform.childCount);
      

                //destPoint = (destPoint + 1) % parentObject.transform.childCount;
                // get vector position of that child object
                Target = Carcasses.transform.GetChild(randomTarget);
                // move agent to that vector position
                Agent.SetDestination(Target.position);
            }
        }
    }






    //void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}

    //void Update()
    //{
    //    // reached to destination
    //    //(!Agent.pathPending && !Agent.hasPath)
    //    if (Agent.hasPath)
    //    {
    //        animator.SetBool("Walk", true);
    //    }
    //    else
    //    {
    //        animator.SetBool("Walk", false);
    //    }

    //}


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        //CoyoteManager.Instance.Units.Add(this);
    }

    // mobes agents to a certain vector position
    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }






    void GotoNextPoint()
    {
        // Choose the next point in the array as the destination,
        //destPoint +=1;

        // If you want the agent to cycle through the points forever you can replace the above code
        // with the code below

        // Make coyote with this component go to a random target so they dont all follow each other
        // to a certain target like a pack, this is to simulate that coyotes hunt alone
        
        int randomTarget = Random.Range(0, List.transform.childCount);
        destPoint = randomTarget;

        //destPoint = (destPoint + 1) % parentObject.transform.childCount;
        // get vector position of that child object
        Target = List.transform.GetChild(destPoint);
        // move agent to that vector position
        MoveTo(Target.position);


    }



   



}