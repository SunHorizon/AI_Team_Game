using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using UnityEngine;

public class particleSystem_SP : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public ParticleSystem prefab;
        public int size;
    }


    public static particleSystem_SP Instance;

    private void Awake()
    {
        Instance = this;
    }
  
    public List<Pool> pools;
    [SerializeField] public Dictionary<string, Queue<ParticleSystem>> poolDictionary;
    
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<ParticleSystem>>();

        foreach (Pool pool in pools)
        {
            Queue<ParticleSystem> objectPool = new Queue<ParticleSystem>();

            for (int i = 0; i < pool.size ; i++)
            {
                ParticleSystem ps = Instantiate(pool.prefab);
                ps.Stop();
                objectPool.Enqueue(ps);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public ParticleSystem SpawnFromPool(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Can't to Spawn object: " + tag);
            return null;
        }

        ParticleSystem ObjectToSpawn =  poolDictionary[tag].Dequeue();
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.Play();

        poolDictionary[tag].Enqueue(ObjectToSpawn);

        return ObjectToSpawn;
    }
}

 
