using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Coyote;
    [SerializeField]
    private GameObject CoyoteButton;

    [SerializeField]
    private GameObject Fox;
    [SerializeField]
    private GameObject FoxButton;

    [SerializeField]
    private GameObject Mission1_UI;
    [SerializeField]
    private GameObject Mission2_UI;
    [SerializeField]
    private GameObject Instructions_UI;
    [SerializeField]
    private GameObject Congratulations_UI;
    bool missionP1Complete;
    bool missionP2Complete;


    // Wolves feature deactivated for now until we
    // can find good models for them

    //[SerializeField]
    //private GameObject Wolf;
    //[SerializeField]
    //private GameObject WolfButton;



    // Start is called before the first frame update
    void Start()
    {
        //coyotePos = GameObject.GetComponent<Transform>.position;
        CoyoteButton.SetActive(false);
        FoxButton.SetActive(false);


        // Until we can get a good wolf model we will wait to implement this
        //WolfButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // finds the distance between the parent object(the player) and a coyote object and dislays Coyote UI in menu
        if(Vector3.Distance(Coyote.transform.position, this.transform.position) < 4f) 
        {
            CoyoteButton.SetActive(true);
            missionP1Complete = true;
        } else if(Vector3.Distance(Fox.transform.position, this.transform.position) < 4f)
        {
            FoxButton.SetActive(true);
            missionP2Complete = true;
        } else if(missionP1Complete && missionP2Complete)
        {
            // if user found both fox and coyote show mission 2 and congragulate them
            Mission1_UI.SetActive(false);
            Instructions_UI.SetActive(false);

            Mission2_UI.SetActive(true);
            Congratulations_UI.SetActive(true);

        }

        // we do not have the wolves available at this time
        //else if(Vector3.Distance(Wolf.transform.position, this.transform.position) < 4f)
        //{
        //    WolfButton.SetActive(true);
        //}
    }
}
