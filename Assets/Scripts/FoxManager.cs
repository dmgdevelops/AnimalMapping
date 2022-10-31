using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DefaultExecutionOrder(0)]
public class FoxManager : MonoBehaviour
{


    IEnumerator MakeAgentsCircleTarget()
    {
        Target = parentObject.transform.GetChild(destPoint);
        for (int i = 0; i < Units.Count; i++)
        {
            // if fox is close to target start positioning them in a circle
            // if not, then have them move in a ordered line like fox packs do

            Units[i].MoveTo(new Vector3(
                Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / Units.Count),
                Target.position.y,
                Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / Units.Count)
                ));


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

    private Transform Target;
    public float RadiusAroundTarget = 0.5f;
    public List<FoxUnit> Units = new List<FoxUnit>();

    //list of targets in scene that make larger path
    [SerializeField]
    private GameObject parentObject;
    private NavMeshAgent agent;
    private int destPoint = 0;
    //[SerializeField] private AudioSource footSteps;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 200, 50), "Move To Target"))
        {
            GotoNextPoint();
            StartCoroutine(MakeAgentsCircleTarget());
        }
    }


}
