using UnityEngine;
using UnityEngine.AI;



// The below code was in part due to a code found within the unity documentation, I changed
// it so that instead of moving the agent with an array of points we can instead reference
// the position of child objects of an empty gameobject

// The following is the link I used to help me implement the following script
// https://docs.unity3d.com/Manual/nav-AgentPatrol.html


public class PlayerNavMash : MonoBehaviour
{
    //list of targets in scene that make larger path
    private GameObject parentObject;
    private NavMeshAgent agent;
    private int destPoint = 0;
    [SerializeField] private AudioSource footSteps;


    void Start()
    {
        // Traditionally we would use an array of points, but here I am using a list of child objects
        // to move the agent
        // Change "Circle" to whatever you named your parent object of targets
        parentObject = GameObject.Find("Circle");

        // without this we would not be able to use regular methods that agents under this component
        // are able to use
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).

        //agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        //plays footsteps sound while agent goes to next target
        footSteps.enabled = true;

        // Set the agent to go to the currently selected destination.
        agent.destination = parentObject.transform.GetChild(destPoint).position;

        // Choose the next point in the array as the destination,
        destPoint = (destPoint + 1);

        // If you want the agent to cycle through the points forever you can replace the above code
        // with the code below

        //destPoint = (destPoint + 1) % parentObject.transform.childCount
    }


    void Update()
    {
        // This will check whether the current target is not at the end child object list,
        // if not it will continue until it gets to the last child object
        if(destPoint< parentObject.transform.childCount)
        {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }

        }
        else if(agent.hasPath == false)// if agent reaches the end of his path 
        {
            ////stops playing footsteps sounds when agent finishes their path
            //footSteps.loop = false;
            footSteps.Stop();
        }

        
            
    }

}
