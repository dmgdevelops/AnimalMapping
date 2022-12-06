using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField]
    private AudioSource achievementSound;

    public void playSound()
    {
        achievementSound.Play();
    }
}
