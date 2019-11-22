using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform SpawnPoint1, SpawnPoint2, SpawnPoint3;
    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Instantiate(bulletPrefab, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            Instantiate(bulletPrefab, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
            Instantiate(bulletPrefab, SpawnPoint3.transform.position, SpawnPoint3.transform.rotation);
            Timer = 0.5f;
        }
    }
}
