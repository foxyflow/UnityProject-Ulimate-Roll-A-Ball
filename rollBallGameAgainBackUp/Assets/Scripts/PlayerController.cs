using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
//Roll a Ball Again developed by Luke Fox 30011364 // Alpha. (foxyflowware@gmail.com)
//Version Control: Unity: 2019.1.0f2
//Working as of 20/07/2019.


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float count;
    public Text countText;
    public Text winText;
    public AudioSource collectSoundSFX; //Audio when player collects items.
    public AudioSource collectMusic;

    public AudioSource m_MyAudioSource; //assigned audiosource to PlayerGameObject
    public AudioClip wonderBoy3;
    public AudioClip finalFantasy;
    public AudioClip finalFantasy2;
    public AudioClip finalFantasy3;
    public AudioClip lowRoar;
    public AudioClip kamelot;
    public AudioClip lastOfUs;
    public AudioClip uncharted;
    public AudioClip lustForLife;
    public AudioClip perfectDark;
    public AudioSource a_recordScrath;
    public AudioClip recordScrath;
    
    public GameObject MenuPanel;

    public Text letsRoll;

    



    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count == 50) //Change this if you add more collectables.
        {
            winText.text = "You Win!";          
        }
        if (count == 60)
        {
            winText.text = "Try get 70";
        }
        if (count == 70)
        {
            winText.text = "RollABall Again!";           
        }
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        //letsRoll.text = "";
        
        collectSoundSFX = GetComponent<AudioSource>(); //Audio when player collects items.
        collectMusic = GetComponent<AudioSource>(); //sound track //I think this does nothing now.
        if (count <=70)
        {
            MenuPanel.gameObject.SetActive(false);
        }
        //UnityEG
        m_MyAudioSource = GetComponent<AudioSource>(); //Fetch the AudioSource from GameObject
        a_recordScrath = GetComponent<AudioSource>();
        // m_Play = true; //music to play at start up
    }

    public bool jump; //Can turn jump on and off in game.
    public void Jump() //Jumping 2 0f 3
    {
        if (Input.GetKeyDown("space") && jump)
        {
            transform.Translate(Vector3.up * 50 * Time.deltaTime, Space.World);
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        Jump(); // 1 of 3      
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            collectSoundSFX.Play(); //Audio SFX when player collects items.
            other.gameObject.SetActive(false);
            count = count + 10;
            SetCountText();
        }
        if (other.gameObject.CompareTag("jump")) //Jumping 3 of 3
        {
            Jump();          
        }
        if (other.gameObject.CompareTag("WonderBoy3"))
        {
            if (m_MyAudioSource && collectSoundSFX)
            {
                m_MyAudioSource.Stop();
                collectSoundSFX.Stop();
            }           
            a_recordScrath.PlayOneShot(recordScrath);
            m_MyAudioSource.PlayOneShot(wonderBoy3);
        }
        if (other.gameObject.CompareTag("Kamelot"))
        {
            if (m_MyAudioSource && collectSoundSFX)
            {
                m_MyAudioSource.Stop();
                collectSoundSFX.Stop();
            }            
            a_recordScrath.PlayOneShot(recordScrath);
            m_MyAudioSource.PlayOneShot(kamelot);
        }
        if (other.gameObject.CompareTag("LowRoar"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(lowRoar);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("Uncharted"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(uncharted);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("FinalFantasy"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(finalFantasy);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("FinalFantasy2"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(finalFantasy2);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("FinalFantasy3"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(finalFantasy3);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("LastOfUsTag"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(lastOfUs);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("LustForLife"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(lustForLife);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("PerfectDark"))
        {
            if (m_MyAudioSource)
            {
                m_MyAudioSource.Stop();
            }
            m_MyAudioSource.PlayOneShot(perfectDark);
            collectSoundSFX.Play();
        }
        if (other.gameObject.CompareTag("StopMusic"))
        {
            m_MyAudioSource.Stop();
        }
    }

    public class Timer : MonoBehaviour
    {
        public Text timeText;
        private float gameTime;
        public GameObject WinPanel;

        private void Start()
        {
            gameTime = 1f;

        }
        void GameTimer()
        {
            if (WinPanel.activeInHierarchy)
            {
                //gameTime = gameTime;
                int displayTime = (int)gameTime;
                timeText.text = displayTime.ToString() + " Seconds";
                Debug.Log("stopped");
            }
            else
            {
                gameTime += Time.deltaTime;
                int displayTime = (int)gameTime;
                timeText.text = displayTime.ToString() + " Seconds";
                Debug.Log("Counting");
            }
        }
        private void Update()
        {
            GameTimer();
        }
    }
  
    public void Level() //Menu in progress
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Restartlevel()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
/*//Start of UnityEG
 * 
 * //UnityEG  
    //public bool m_Play; //play the music //NOT IN USE
    //public bool m_ToggleChange; //make sure one audio is played at a time. COMMENTED OUT
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
   private void OnGUI() //UnityEG
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
   *///End of UnityEG
     /*
     else if (other.gameObject.CompareTag("Start Music")) //Sound track plays after collecting first dimond
     {
         if (collectMusic)
         {
             collectMusic.PlayOneShot(collisionSound);
             if (addingToUnityEG)
             {
                 m_MyAudioSource.Stop();
             }
             other.gameObject.SetActive(false);
         }
         collectSoundSFX.Play();
         collectMusic.Stop();

         other.gameObject.SetActive(false);
         count = count + 10;
         SetCountText();
     }
     */

/* if (other.gameObject.CompareTag("Play Music")) //Sound track plays after collecting first dimond
  {
      if (collectMusic)
      {
          collectMusic.PlayOneShot(addingToUnityEG);

          {
              other.gameObject.SetActive(false);
          }

      }
      collectSoundSFX.Play();
      other.gameObject.SetActive(false);
      count = count + 10;
      SetCountText();

  }
*/

