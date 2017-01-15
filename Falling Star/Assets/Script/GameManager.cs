using UnityEngine;
using System.Collections;
using Assets.Script;

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

    public void Lost_Game(int score)
    {
        if ((GameProperties.GamePlayCount % GameProperties.InterstitialGameSize) == 0)
        {
            //AdManager.Instance.RequestInterstitial();
            AdManager.Instance.ShowInterstitial();
        }
        bool earnActive = false;
        if (GameProperties.GamePlayCount >= 5 && ((GameProperties.GamePlayCount % GameProperties.RewardGameSize) == 0))
        {
            AdManager.Instance.RequestRewardAd();
            earnActive = true;
        }

        uiManager.Load_LostMenu(score, earnActive);
        PlayGame = false;

        GameObject.FindWithTag("Player").transform.position = new Vector3(0, -2.5f, 0);
        GameObject.Find("Player").GetComponent<PlayerControl>().Default();
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] OrbList = GameObject.FindGameObjectsWithTag("Orb");
        foreach (var orb in OrbList)
        {
            Destroy(orb);
        }
        foreach (var enemy in EnemyList)
        {
            Destroy(enemy);
        }
        Time.timeScale = 1;

    }

    public void Reload_Game()
    {
        

        uiManager.Load_MainMenu();
        PlayGame = false;
        
        GameObject.FindWithTag("Player").transform.position = new Vector3(0, -2.5f, 0);
        GameObject.Find("Player").GetComponent<PlayerControl>().Default();
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] OrbList = GameObject.FindGameObjectsWithTag("Orb");
        foreach(var orb in OrbList)
        {
            Destroy(orb);
        }
        foreach (var enemy in EnemyList)
        {
            Destroy(enemy);
        }
        Time.timeScale = 1;
    }
}
