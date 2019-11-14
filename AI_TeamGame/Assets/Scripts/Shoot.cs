using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Shoot : MonoBehaviour
{

    [Header("Data")]
    [SerializeField] private DataFloat JumpInput;

    [Header("References")]
    [SerializeField] private Data data;

    [Header("Attack Info")]
    [SerializeField] private bullet Bullet;
    [SerializeField] private GameObject BulletSpawnLocation;


    private bool shootDelay;
    // Use this for initialization
    void Start ()
    {
        JumpInput = data.Float(JumpInput);

        shootDelay = true;
    }
	
	// Update is called once per frame
	void Update () {

        if ((float) JumpInput >= 1)
        {
            if (shootDelay == true)
            {
                //Debug.Log(("Shoot"));
                Instantiate(Bullet, BulletSpawnLocation.transform.position, BulletSpawnLocation.transform.rotation);
            }
            shootDelay = false;      
        }

        if ((float)JumpInput == 0)
        {   
            shootDelay = true;
        }
    }
   
}
