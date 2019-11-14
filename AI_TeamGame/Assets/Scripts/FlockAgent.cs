using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Collider2D)))]
public class FlockAgent : MonoBehaviour
{

     private Collider2D agentCollider;
     public Collider2D AgentCollider { get { return  agentCollider; } }


     [SerializeField] private string BulletName;
     [SerializeField] private string playerName;
     private bool Destroyed;
    

    // Use this for initialization
    void Start ()
    {
        agentCollider = GetComponent<Collider2D>();
        Destroyed = false;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == BulletName)
        {
            GameScore.points += 5;
            Destroyed = true;
            Destroy(gameObject);
        }

        if (other.tag == playerName)
        {
            Destroyed = true;
            particleSystem_SP.Instance.SpawnFromPool("Paricle", gameObject.transform.position);
            Destroy(gameObject);
        }
    }

    public bool getDestroyed()
    {
        return Destroyed;
    }
}
