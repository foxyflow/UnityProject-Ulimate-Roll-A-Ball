using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    public Text timeText;
    public float count;
    private bool finished = false; //go to stop time method.

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (finished) //trying to stop the timer.
           return;
        
        GameTimer();
    }

    void GameTimer()
    {
        count += Time.deltaTime;
        int displayTime = (int)count;

        timeText.text = displayTime.ToString() + "";
    }

    public void StopTime() // to stop time method
    {
        if (count >= 10)
        {
            
            timeText.color = Color.green;
            finished = true;

        }
       
    }

}

