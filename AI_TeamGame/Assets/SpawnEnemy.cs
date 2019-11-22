using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> spawns = new List<GameObject>();

    [SerializeField] private float SpawnTimer;
    [SerializeField] private GameObject Enemy;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int spawnPoint = Random.Range(0, spawns.Count);
            Instantiate(Enemy, spawns[spawnPoint].transform.position, spawns[spawnPoint].transform.rotation);
            timer = SpawnTimer;
        }
    }
}
