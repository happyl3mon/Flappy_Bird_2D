using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    [SerializeField] private float heightRange;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] GameObject pipe;
    [SerializeField] GameObject player;
    public static bool resetGameCall = false;
    private float timer;
    private bool resetTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
        player.GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.runGame == true)
        { 
            Time.timeScale = 1; 
            resetGameCall = false;

            if (resetTimer == true)
            {
                SpawnPipe();
                resetTimer = false;
            }

            if (timer > maxTime)
            {
                SpawnPipe();
                timer = 0;
            }
            timer += Time.deltaTime;
        } else if (controller.runGame == false)
        {
            Time.timeScale = 0;
            
            if (resetGameCall == true)
            {
                Debug.Log("resetGameCall TRUE");
                ResetGame();
                Time.timeScale = 1;
                resetTimer = true;
                timer = 0f;
                controller.runGame = true;
            }
        }
    }

    void SpawnPipe()
    {
        Vector2 spawnPosition = new Vector2(2f, Random.Range(-heightRange, heightRange));
        GameObject pipeInstance = Instantiate(pipe, spawnPosition, Quaternion.identity); 
        Destroy(pipeInstance, 3f);
        
    }
     
    void ResetGame()
    {
        Debug.Log("ResetGame Function");
        GameObject[] allPipes = GameObject.FindGameObjectsWithTag("pipe_tag");
        foreach(GameObject gameObject in allPipes)
        {
            Destroy(gameObject);
        }

        resetGameCall = false;
    }
}
