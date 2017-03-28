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

        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    private GameObject getEnemy(Vector3 pos, Quaternion qua)
    {
        return enemyPool.GetObject(pos, qua);
    }

    private GameObject getOrb(Vector3 pos, Quaternion qua)
    {
        return orbPool.GetObject(pos, qua);
    }

    public void SpawnerStop()
    {
        StopCoroutine(Spawner());
    }

    public void SpawnerBegin()
    {
        SpawnerStop();
        StartCoroutine(Spawner());
    }
	
    private Vector3 spawnPoint;

    private void RandomPostion()
    {
        spawnPoint.Set(Random.Range(-2.5f, 2.5f), this.transform.position.y, 0);
    }



    private void enemyLevel()
    {
        spawnShip = Random.Range(0, HowWave);
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

                SpawnTime = 0.5f;
                int wave = OrbManager.Instance.getOrb / 10;
                wave = Mathf.Clamp(wave, 1, enemy.Length);
                HowWave = wave;
                PlayerControl.Instance.Set_Vertical_Speed(-(((float)wave) / 5) + -3.5f);
                SpawnTime = (((float)wave) / (2 * enemy.Length))  + SpawnTime;
                waveRandom();
            }
            else
            {
                StopCoroutine(Spawner());
                break;
            }
        }
        
    }
}
