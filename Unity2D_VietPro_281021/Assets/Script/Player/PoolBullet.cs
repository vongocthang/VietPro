using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBullet : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject prefab;
        public int size;
    }

    public static PoolBullet instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pool;

    Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool p in pool)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for(int i = 0; i < p.size; i++)
            {
                GameObject obj = Instantiate(p.prefab);
                obj.SetActive(false);

                objPool.Enqueue(obj);
            }

            poolDictionary.Add(p.name, objPool);
        }
    }

    public GameObject SpawmPool(string name,Vector2 position,Quaternion rotation)
    {
        Debug.Log("Ban dan");

        GameObject objSpawm = poolDictionary[name].Dequeue();

        objSpawm.transform.position = position;
        objSpawm.transform.rotation = rotation;
        objSpawm.SetActive(true);

        poolDictionary[name].Enqueue(objSpawm);

        return objSpawm;
    }
}
