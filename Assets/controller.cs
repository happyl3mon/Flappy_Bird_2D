using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private KeyCode keySelect;
    [SerializeField] private float linearVelocityMultiplier;
    [SerializeField] private GameObject obstacle;
    public static KeyCode restartGameInput = KeyCode.Backspace;
    public static bool runGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D.GetComponent<Rigidbody2D>();
        runGame = true;
        obstacle.GetComponent<obstacleSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(runGame == true)
        {
            //rigidbody2D.gravityScale = 4.5f;
            if (Input.GetKeyDown(keySelect))
            {
                rigidbody2D.linearVelocityY += linearVelocityMultiplier;
            }

        } else if (runGame == false)
        {
            //rigidbody2D.gravityScale = 0f;
            if (Input.GetKeyDown(restartGameInput))
            {
                obstacleSpawn.resetGameCall = true;
                ResetPlayer();
              //  Debug.Log(obstacleSpawn.resetGameCall);

               // Debug.Log(obstacleSpawn.resetGameCall);
                
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        runGame = false;
        //Debug.Log("runGame set to false");
        //Debug.Log("The Player has Collided with an Obstacle");
    }

    void ResetPlayer()
    {
        transform.position = new Vector3(0f, 0f);
        //Debug.Log("restartGame activated");
    }
}
