using NUnit.Framework;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scoreTracker : MonoBehaviour
{
    private float scoreCount;
    //private float lastRunScore = 0;
    private float highScore = 0;
    private bool isFirstRun;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreCount = 0f;
        isFirstRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.hasCollided);
 
        Debug.Log(scoreCount + " is current score");


        if (controller.hasCollided == true)
        {
            //Debug.Log(lastRunScore + " is the previous score");
            Debug.Log(highScore + " is new high score");
        }        

        if (Input.GetKeyDown(controller.restartGameInput))
        {
            isFirstRun = false;
        }

        if (controller.runGame == true)
        {
            scoreCount += Time.deltaTime;  

        }

        if (controller.runGame == false)
        {
            //lastRunScore = scoreCount;

            if (isFirstRun == true || highScore < scoreCount)
            {
                Debug.Log("FIRST RUN? " + isFirstRun);
                
                highScore = scoreCount;
            }

            if (Input.GetKeyDown(controller.restartGameInput))
            {
                scoreCount = 0f;
            }
        }
    }
}
