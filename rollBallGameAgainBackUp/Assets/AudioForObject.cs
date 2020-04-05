using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioForObject : MonoBehaviour
{

   // public AudioClip audioClip;


   public AudioSource m_MyAudioSource; //assigned audiosource to GameObject
   public bool m_Play; //play the music
   public bool m_ToggleChange; //make sure one audio is played at a time.

    private void Start()
    {
        //UnityEG
        m_MyAudioSource = GetComponent<AudioSource>(); //Fetch the AudioSource from GameObject
        m_Play = true; //music to play at start up
        
    }

    private void Update()
    {
        //UnityEG
        //check to see if toggle is positive:
        if (m_Play == true && m_ToggleChange == true)
        {
            //Play the audio you attach to the AudioSource
            m_MyAudioSource.Play();
            //Ensure audio doesn't play more than once:
            m_ToggleChange = false;
        }
        //Check if you just set the toggle to false
        if (m_Play == false && m_ToggleChange == true)
        {
            //Stop the audio:
            m_MyAudioSource.Stop();
            //Ensure audio doesn't play more than once:
            m_ToggleChange = false;
        }
    }



    /* private void OnGUI()
     {
        //Switch this toggle to activate and deactivate the parent GameObject:
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there is just a change in the toggle state.
            m_ToggleChange = true;
        }
     }
     */









}
