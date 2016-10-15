using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemy;
    private GameManager gameManager;
    // Use this for initialization
	void Start () {

        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        InvokeRepeating("Spawner", 1, 3.2f);


    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (gameManager.PlayGame)
            this.transform.position = new Vector3(Random.Range(-3f, 3f), this.transform.position.y);

    }
    void Spawner()
    {
     
     if(gameManager.PlayGame)   
        Instantiate(enemy[0], this.transform.position, Quaternion.identity);
    }
}
