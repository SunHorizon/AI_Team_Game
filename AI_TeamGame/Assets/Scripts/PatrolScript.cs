using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{

    [Header("Info")]
    //[SerializeField] private float timeValue;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 orientation;
    [SerializeField] private Vector3 currentNode;
    [SerializeField] private int nodeIndex;
    [SerializeField] private GameObject [] Nodes;

    // Start is called before the first frame update
    void Start()    
    {
        nodeIndex = 0;
        currentNode = Nodes[nodeIndex].transform.position;
    }

    // Update is called once per frame  
    void Update()
    {
        PatrolAI();
        Chase(currentNode);
    }

    void PatrolAI()
    {
        if(Nodes.Length == 0)
        {
            return;
        }
        if(Vector3.Distance(transform.position, Nodes[nodeIndex].transform.position) < 1.0f)
        {
            if(nodeIndex == Nodes.Length -1)
            {
                nodeIndex = 0;
            }
            else
            {
                nodeIndex++;
            }
            currentNode = Nodes[nodeIndex].transform.position;
        }
    }

    void Chase(Vector3 target_)
    {
 
        float dt = Time.deltaTime;
        Vector3 dir = target_ - gameObject.transform.position;

        orientation = dir;

        UpdateOrientation();

        Vector3 pos = transform.position;
        Vector3 velocity = orientation.normalized * speed;

        pos += velocity * dt;
        transform.position = pos;
    }

    void UpdateOrientation()
    {
        Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(orientation.x, orientation.y) * Mathf.Rad2Deg);
        transform.eulerAngles = angle;
    }

    //void MovementDirection(Vector3 dir_, float targetTime_)
    //{
    //        timeValue = targetTime_;

    //        timeValue -= Time.deltaTime;

    //        Vector3 pos = transform.position;

    //        pos += dir_ * Time.deltaTime;

    //        transform.position = pos;

    //        if (timeValue <= 0.0f)
    //        {
    //            return;
    //        }
    //}
}
