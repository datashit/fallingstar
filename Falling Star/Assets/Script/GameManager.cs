using UnityEngine;
using System.Collections;
using Assets.Script;

public class GameManager : MonoBehaviour {

    public bool PlayGame = false;
    public SpawnEnemy EnemySpawner;

    public UImanager uiManager;

	// Use this for initialization
	void Start () {

        PlayGame = false;
        
	}
	
    
	// Update is called once per frame
	void Update () {

	}


    private void Clear_Scene()
    {
        PlayGame = false;

        GameObject.FindWithTag("Player").transform.position = new Vector3(0, -2.5f, 0);
        GameObject.Find("Player").GetComponent<PlayerControl>().Default();
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] OrbList = GameObject.FindGameObjectsWithTag("Orb");
        foreach (var orb in OrbList)
        {
            orb.SetActive(false);
        }
        foreach (var enemy in EnemyList)
        {
            enemy.SetActive(false);
        }
        Time.timeScale = 1;
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
        Clear_Scene();

    }

    public void Reload_Game()
    {
        uiManager.Load_MainMenu();
        Clear_Scene();
    }

    public void Play()
    {
        OrbManager.Instance.Orb_Clear();
        EnemySpawner.SpawnerBegin();
    }
}
