using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoveryManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Coyote;
    [SerializeField]
    private GameObject CoyoteButton;
    [SerializeField]
    private GameObject CoyoteFoodSource;
    [SerializeField]
    private GameObject CoyotePreyButton;


    [SerializeField]
    private GameObject Fox;
    [SerializeField]
    private GameObject FoxButton;
    [SerializeField]
    private GameObject FoxFoodSource;
    [SerializeField]
    private GameObject FoxPreyButton;


    [SerializeField]
    private GameObject Mission1_UI;
    [SerializeField]
    private GameObject Mission2_UI;
    //[SerializeField]
    //private GameObject Congratulations_Object;

    [SerializeField]
    private AudioSource achievementSound;

    // Mission One part one is to find coyotes
    bool missionOneP1Complete;
    // Mission One part two is to find foxes
    bool missionOneP2Complete;
    // Mission Two part one is to find what coyotes eat
    bool missionTwoP1Complete;
    // Mission two part two is find what foxes eat
    bool missionTwoP2Complete;


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

        missionOneP1Complete = false;
        missionOneP2Complete = false;

        missionTwoP1Complete = false;
        missionTwoP2Complete = false;

        //Congratulations_Object.SetActive(false);


        // Until we can get a good wolf model we will wait to implement this
        //WolfButton.SetActive(false);
    }





    // Update is called once per frame
    void Update()
    {
        // if the player has not completed both parts of mission
        // keep checking if they complete mission, which calls function below

        // if the player has completed mission one then check if they completed mission two

        
        if (!missionOneP1Complete || !missionOneP2Complete)
        {
            MissionOne();
        }
        else if (missionOneP1Complete && missionOneP2Complete)
        {
            MissionTwo();
        } else if (missionTwoP1Complete && missionTwoP2Complete)
        {
            // new bigger sign
            //Congratulations_Object.SetActive(true);





            // Debug files, the congratulations sign was not enabled at the end of the experience
            
        }    



        // we do not have the wolves available at this time
        //else if(Vector3.Distance(Wolf.transform.position, this.transform.position) < 4f)
        //{
        //    WolfButton.SetActive(true);
        //}
    }










    // the following function checks if the player has completed mission one

    private void MissionOne()
    {
        // finds the distance between the parent object(the player) and a coyote object and dislays Coyote UI in menu

        if (Vector3.Distance(Coyote.transform.position, this.transform.position) < 200f)
        {
            CoyoteButton.SetActive(true);
            missionOneP1Complete = true;
            Debug.Log("Found Coyotes");
        }

        if (Vector3.Distance(Fox.transform.position, this.transform.position) < 35f)
        {
            FoxButton.SetActive(true);
            missionOneP2Complete = true;
            Debug.Log("Found Foxes");
        }

        if (missionOneP1Complete && missionOneP2Complete)
        { 

            // if user found both fox and coyote show mission 2 and congragulate them
            Mission1_UI.SetActive(false);

            Mission2_UI.SetActive(true);

        }

    }









    // the following function checks if the player has completed mission two

    private void MissionTwo()
    {
        // if the player is by the foxes and their food source show message that they discovered
        // what foxes eat and maybe display that information in tablet

        if (Vector3.Distance(Fox.transform.position, this.transform.position) < 35f && Vector3.Distance(FoxFoodSource.transform.position, this.transform.position) < 35f)
        {
            // the following code was for mission One use the same code but change variables and gameobjects to fit mission two

            //CoyoteButton.SetActive(true);
            //missionP1Complete = true;

            //GUI.Button(new Rect(20, 20, 200, 50), "You Found What Foxes Eat!");


            FoxPreyButton.SetActive(true);
            missionTwoP1Complete = true;
            Debug.Log("Found what Foxes eat!");
        }

        if (Vector3.Distance(Coyote.transform.position, this.transform.position) < 35f && Vector3.Distance(CoyoteFoodSource.transform.position, this.transform.position) < 35f)
        {
            // the following code was for mission One use the same code but change variables and gameobjects to fit mission two

            //CoyoteButton.SetActive(true);
            //missionP1Complete = true;

            //GUI.Button(new Rect(20, 20, 200, 50), "You Found What Foxes Eat!");
            CoyotePreyButton.SetActive(true);
            missionTwoP2Complete = true;
            Debug.Log("Found what Coyotes eat!");
        }

    }




}
