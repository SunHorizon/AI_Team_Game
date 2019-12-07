using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawBackground : MonoBehaviour
{
    public GameObject Spawned;
    public float SpawnRadius;
    public float startSpawnRadius = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawns());
    }

    void Update()
    {
        SpawnRadius = startSpawnRadius;
    }
    void Spawn_Enemy()
    {
        Vector2 SpawnPos;
        SpawnPos = Random.insideUnitCircle.normalized * SpawnRadius;
        Instantiate(Spawned, SpawnPos, Quaternion.identity);
    }

    IEnumerator Spawns()
    {
        yield return new WaitForSeconds(1f);
        Spawn_Enemy();
        StartCoroutine(Spawns());
    }
    // Update is called once per frame

}
