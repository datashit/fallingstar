using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemy;
    // Use this for initialization
	void Start () {
        InvokeRepeating("Spawner", 1, 3.2f);


    }
	
	// Update is called once per frame
	void LateUpdate () {

        this.transform.position = new Vector3(Random.Range(-3f, 3f), this.transform.position.y);

    }
    void Spawner()
    {
     
        
        Instantiate(enemy[0], this.transform.position, Quaternion.identity);
    }
}
