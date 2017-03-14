using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemy;
    public GameObject[] Orbs;
    public GameObject[] Powers;

    public float SpawnStartTime = 3f;
    public float SpawnTime = 3f;

    private GameObjectPool orbPool;
    private List<GameObjectPool> enemyPoolList;
    private GameObjectPool enemyPool;
    //private List<GameObject> orbPool;
    //private List<GameObject> enemyPool;
    public ushort PoolSize = 20;
    private GameManager gameManager;
    private int spawnShip;
    // Use this for initialization
	void Start () {
        //orbPool = new List<GameObject>();
        orbPool = new GameObjectPool(Orbs[0], this.transform, PoolSize);
        enemyPoolList = new List<GameObjectPool>();
        foreach(var obj in enemy)
        {
            enemyPoolList.Add(new GameObjectPool(obj, this.transform, PoolSize));
        }
        enemyPool = new GameObjectPool(enemy[0], this.transform, PoolSize);

        HowWave = -1;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
        StartCoroutine(Spawner());
        
    }

    private GameObject getEnemy(Vector3 pos, Quaternion qua)
    {
        return enemyPool.GetObject(pos, qua);
    }

    private GameObject getOrb(Vector3 pos, Quaternion qua)
    {
        return orbPool.GetObject(pos, qua);
        //for(int i=0; i < orbPool.Count; i++)
        //{
        //    if(!orbPool[i].activeInHierarchy)
        //    {
        //        orbPool[i].transform.position = pos;
        //        orbPool[i].transform.rotation = qua;
        //        orbPool[i].SetActive(true);
        //        return orbPool[i];
        //    }
        //}
        //return null;
    }
    private void SpawnerBegin()
    {
        InvokeRepeating("Spawner", SpawnStartTime, SpawnTime);
    }
	
    private Vector3 spawnPoint;

    private void RandomPostion()
    {
        spawnPoint.Set(Random.Range(-2.5f, 2.5f), this.transform.position.y, 0);
    }

    private void wave0()
    {
        RandomPostion();
        getOrb(spawnPoint, Quaternion.identity);
    }


    private void enemyLevel()
    {
        int enemyLen = 1;
        
        if (OrbManager.Instance.getOrb <= 50)
        {
            enemyLen = 1;
        }
        else if(OrbManager.Instance.getOrb <= 80)
        {
            enemyLen = 2;
        }
        spawnShip = Random.Range(0, enemyLen);
    }

    private void waveRandom()
    {
        RandomPostion();
        enemyLevel();
        if (Random.Range(0, 2) == 0)
        {
            //Instantiate(enemy[spawnShip], spawnPoint, Quaternion.identity);
            enemyPoolList[spawnShip].GetObject(spawnPoint, Quaternion.identity);
            //getEnemy(spawnPoint, Quaternion.identity);
        }
        else
        {
            getOrb(spawnPoint, Quaternion.identity);
        }
    }


    private int HowWave = 0;
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(SpawnStartTime);
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            if (gameManager.PlayGame)
            {
                if (OrbManager.Instance.getOrb == HowWave)
                {
                    switch (HowWave)
                    {
                        case 10:
                            SpawnStartTime = 0f;
                            SpawnTime = 0.6f;
                            break;
                        case 50:
                            SpawnStartTime = 0f;
                            SpawnTime = 0.5f;
                            break;
                    }

                    HowWave = -1;
                    //CancelInvoke("Spawner");
                    //SpawnerBegin();
                    continue;
                }
                if (OrbManager.Instance.getOrb <= 10)
                {
                    HowWave = 10;
                    PlayerControl.Instance.Set_Vertical_Speed(-3.5f);
                    wave0();
                }
                else if (OrbManager.Instance.getOrb <= 50)
                {
                    HowWave = 50;
                    PlayerControl.Instance.Set_Vertical_Speed(-4f);
                    waveRandom();
                }
                else if (OrbManager.Instance.getOrb >= 50)
                {
                    PlayerControl.Instance.Set_Vertical_Speed(-4.5f);
                    waveRandom();
                }
            }
            else
            {
                HowWave = -1;
            }
        }
        
    }
}
