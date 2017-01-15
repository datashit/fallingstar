using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemy;
    public GameObject[] wave;

    public float SpawnStartTime = 3f;
    public float SpawnTime = 10f;

    private GameManager gameManager;
    private int spawnShip;
    // Use this for initialization
	void Start () {

        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        InvokeRepeating("Spawner", SpawnStartTime, SpawnTime);


        


    }
	
	// Update is called once per frame
	void LateUpdate () {
        //if (gameManager.PlayGame)
        //{
        //    this.transform.position = new Vector3(Random.Range(-3f, 3f), this.transform.position.y);
        //    spawnShip =  Random.Range(0, enemy.Length);
        //}
    }

    private Vector3 spawnPoint;
    void Spawner()
    {
         if(gameManager.PlayGame)
         {
            spawnPoint.Set(Random.Range(-3f, 3f), this.transform.position.y, 0);
            spawnShip = Random.Range(0, enemy.Length);
            Instantiate(enemy[spawnShip], spawnPoint, Quaternion.identity);
         }
        
    }
}
