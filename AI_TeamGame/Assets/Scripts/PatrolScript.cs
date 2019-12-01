using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{

    [Header("Info")]
    [SerializeField] private List<DirectionNode> Instructions; 
    // Start is called before the first frame update
    void Start()
    {
        Instructions = new List<DirectionNode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PatrolAI()
    {

    }
}
