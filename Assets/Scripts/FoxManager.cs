using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(0)]
public class FoxManager : MonoBehaviour
{
    public LightingManager _LM;

    bool Move;

    Animator animator;
    private Transform Target;
    public float RadiusAroundTarget = 0.5f;
    public List<FoxUnit> Units = new List<FoxUnit>();

    //list of targets in scene that make larger path
    [SerializeField]
    private GameObject parentObject;
    private NavMeshAgent agent;
    private int destPoint = 0;
    //[SerializeField] private AudioSource footSteps;






    private static FoxManager _instance;
    public static FoxManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }




    IEnumerator MakeAgentsCircleTarget()
    {
        Target = parentObject.transform.GetChild(destPoint);
        //animator = Target.GetComponent<Animator>();
        for (int i = 0; i < Units.Count; i++)
        {
            // if fox is close to target start positioning them in a circle
            // if not, then have them move in a ordered line like fox packs do

            Units[i].MoveTo(new Vector3(
                Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / Units.Count),
                Target.position.y,
                Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / Units.Count)
                ));

            //animator.SetBool("Walk", false);

            //if (Vector3.Distance(Units[i].transform.position, Target.transform.position) < 0.5f)
            //{
            //    Units[i].MoveTo(new Vector3(
            //    Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / Units.Count),
            //    Target.position.y,
            //    Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / Units.Count)
            //    ));
            //    StartCoroutine(loopDelay());
            //} else
            //{

            //}
            print("started delay");
            yield return new WaitForSeconds(2);

        }

    }




    void GotoNextPoint()
    {
        // Choose the next point in the array as the destination,
        //destPoint +=1;

        // If you want the agent to cycle through the points forever you can replace the above code
        // with the code below

        destPoint = (destPoint + 1) % parentObject.transform.childCount;

    }


   









    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }




    /* the following code that is commented did not work since by the time we set the boolean Move false it will get
     * reset to true and keep resetting the destinations of the agents causing them to stay in place
     */


    // I wanted to have the foxes animation changed based on the time of day since the foxes either stay on walking or idle animation
    private void Update()
    {
        //animator.SetBool("Walk", Move);
    }


    private void Start()
    {
        StartCoroutine(MoveFox());
        
        Move = false;
    }




    IEnumerator MoveFox()
    {
        while(Application.isPlaying)
        {
            yield return new WaitForSeconds(1);

            if (_LM.getTimeOfDay() == (int)(5 * 13))
            {
                StartAgentMethods();
                //Move = true;
            }
            else if (_LM.getTimeOfDay() == (int)(7 * 13))
            {
                StartAgentMethods();
                //Move = false; 
            }
            else if (_LM.getTimeOfDay() == (int)(18 * 13))
            {
                StartAgentMethods();
                //Move = true;
            }
            else if (_LM.getTimeOfDay() == (int)(20 * 13))
            {
                StartAgentMethods();
                //Move = true;
            }
        }
    }




    private void StartAgentMethods()
    {


        GotoNextPoint();
        StartCoroutine(MakeAgentsCircleTarget());
        Debug.Log("Move");
    }



    //private void OnGUI()
    //{
    //    if (GUI.Button(new Rect(20, 20, 200, 50), "Move To Target"))
    //    {
    //        GotoNextPoint();
    //        StartCoroutine(MakeAgentsCircleTarget());
    //    }
    //}


}
