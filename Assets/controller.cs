using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private KeyCode keySelect;
    [SerializeField] private float linearVelocityMultiplier;
    [SerializeField] private KeyCode restartGame;
    public static bool runGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D.GetComponent<Rigidbody2D>();
        runGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(runGame == true)
        {
            //rigidbody2D.gravityScale = 4.5f;
            Time.timeScale = 1;
            if (Input.GetKeyDown(keySelect))
            {
                rigidbody2D.linearVelocityY += linearVelocityMultiplier;
            }

        } else if (runGame == false)
        {
            //rigidbody2D.gravityScale = 0f;
            Time.timeScale = 0;
            if (Input.GetKeyDown(restartGame))
            {
                RestartGame();
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        runGame = false;
        Debug.Log("runGame set to false");
        Debug.Log("The Player has Collided with an Obstacle");
    }

    void RestartGame()
    {
        runGame = true;
        transform.position = new Vector3(0f, 0f);
        Debug.Log("restartGame activated");
    }
}
