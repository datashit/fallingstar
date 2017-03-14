using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace UnityEngine
{
    class GameObjectPool: MonoBehaviour
    {
        private List<GameObject> pool;
        public GameObjectPool(GameObject gameObject, Transform transform, UInt16 PoolSize)
        {
            pool = new List<GameObject>();
            objectSize = PoolSize;
            for (int i = 0; i < PoolSize; i++)
            {
                GameObject obj = Instantiate(gameObject, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }

        public GameObject GetObject(Vector3 pos, Quaternion qua)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    pool[i].transform.position = pos;
                    pool[i].transform.rotation = qua;
                    pool[i].SetActive(true);
                    return pool[i];
                }
            }
            return null;
        }
         
        private UInt16 objectSize;
        public UInt16 ObjectSize
        {
            get
            {
                return objectSize;
            }
        }

        
    }
}
