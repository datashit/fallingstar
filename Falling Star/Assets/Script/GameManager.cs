using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public bool PlayGame = false;
    public GameObject EnemySpawner;

    public UImanager uiManager;
	// Use this for initialization
	void Start () {

        PlayGame = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Reload_Game()
    {
        uiManager.Load_MainMenu();
        PlayGame = false;
        Time.timeScale = 1;
        GameObject.FindWithTag("Player").transform.position = new Vector3(0, -2.5f, 0);
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in EnemyList)
        {
            Destroy(enemy);
        }
    }
}
