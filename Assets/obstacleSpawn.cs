using UnityEngine;

public class obstacleSpawn : MonoBehaviour
{
    [SerializeField] private float heightRange;
    [SerializeField] private float maxTime = 5f;
    [SerializeField] GameObject pipe;
    [SerializeField] GameObject player;
    private float timer;

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
            if (timer > maxTime)
            {
                SpawnPipe();
                timer = 0;
            }
            timer += Time.deltaTime;
        } else
        {
            DestroyPipe();
        }
    }

    void SpawnPipe()
    {
        Vector2 spawnPosition = new Vector2(2f, Random.Range(-heightRange, heightRange));
        GameObject pipeInstance = Instantiate(pipe, spawnPosition, Quaternion.identity); 
        Destroy(pipeInstance, 3f);
    }
     
    void DestroyPipe()
    {
       // Destroy(pipeInstance, 0f);
    }
}
