using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject AnimalPick;
    [SerializeField]
    private GameObject AnimalDetails;
    private bool paused;

    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Transform playerBody;
    private float xRotation = 0f;


    //void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(AnimalDetails.active == true || AnimalPick.active == true)
            {
                ResumeGame();
                
            }
            else if(AnimalDetails.active == false || AnimalPick.active == false)
            {
                PauseGame();
                ////Will open or close menu based on current state
                //AnimalPick.SetActive(!AnimalPick.activeSelf);
            }

        } 
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        //AudioListener.pause = true;
        paused = true;
        AnimalPick.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //AudioListener.pause = false;
        paused = false;
        AnimalPick.SetActive(false);
        AnimalDetails.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;

    }

}
