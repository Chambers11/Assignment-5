using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Player player;
    public GameObject enemyPrefab;
    public float enemySpawnDistance = 20f; 

    public float enemyInterval = 2.0f;
    public float minimumEnemyInterval = 0.5f;
    public float enemyIntervalDecrement = 0.1f;

    private float enemyTimer = 0f; 

   
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer -= Time.deltaTime;
        if (enemyTimer <= 0)
        {
            enemyTimer = enemyInterval;
            enemyInterval -= enemyIntervalDecrement;



            if (enemyInterval < minimumEnemyInterval)
            {
                enemyInterval = minimumEnemyInterval;
            }
                GameObject enemyObject = Instantiate(enemyPrefab);
                Enemy enemy = enemyObject.GetComponent<Enemy>();
                
                float randomAngle = Random.Range(0f,2f* Mathf.PI);
                enemy.transform.position = new Vector3(
                player.transform.position.x + Mathf.Cos(randomAngle)*enemySpawnDistance,
                 enemy.transform.position.y,
                 player.transform.position.z + Mathf.Sin(randomAngle)*enemySpawnDistance
                ); 
                enemy.direction = (player.transform.position - enemy.transform.position).normalized;
                
            }
            
           
        }
    
}
