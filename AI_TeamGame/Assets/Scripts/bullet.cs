using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private float timer;

    [Header("Component")]
    [SerializeField] private Rigidbody2D rigidbody;

    [Header("Data")]
    [SerializeField] private float BulletSpeed;
      
    // Use this for initialization
    void Start ()
    {
        timer = 2.0f;
     
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Timer to destroy the bullet
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            
            Destroy(gameObject);
        }

        rigidbody.AddForce(gameObject.transform.up * BulletSpeed * 10);
       
    }
}
