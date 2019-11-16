using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    private Vector3 orientation = Vector3.up;
    [SerializeField] private float speed;
    private Vector3 velocity;
    [SerializeField] private string name;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        orientation = Vector3.down * speed;
        UpdateOrientation();

        velocity = orientation.normalized * speed;
        transform.position += velocity * Time.deltaTime;
    }

    void UpdateOrientation()
    {
        Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(orientation.x, orientation.y) * Mathf.Rad2Deg);
        transform.eulerAngles = angle;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == name)
        {
            Destroy(gameObject);
        }
    }
}
