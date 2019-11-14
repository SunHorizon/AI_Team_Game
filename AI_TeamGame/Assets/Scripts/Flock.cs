using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Flock : MonoBehaviour
{

    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FloakBehavior behavior;

    [Range(1f, 100f)]
    public float driveFactor = 10f;

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;


    private float squareMaxSpeed;
    private float squareNeighborRadius;
    private float squareAvoidanceRadius;
    public  float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    [SerializeField] List<GameObject> spawns = new List<GameObject>();

    [SerializeField] private float SpawnTimer;
    [SerializeField] private GameObject player;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        timer = SpawnTimer;
  
    }

    // Update is called once per frame
    void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int spawnPoint = Random.Range(0, spawns.Count);
            FlockAgent newAgent = Instantiate(agentPrefab, spawns[spawnPoint].transform.position, spawns[spawnPoint].transform.rotation);
            agents.Add(newAgent);
            timer = SpawnTimer;
        }
        Debug.Log("Running");

        foreach (FlockAgent agent in agents)
        {
            if (agent)
            {
                List<Transform> context = getNearbyObjects(agent);

                Vector2 move = behavior.CalculateMove(agent, context, this, player);
                move *= driveFactor;
                if (move.sqrMagnitude > squareMaxSpeed)
                {
                    move = move.normalized * maxSpeed;
                }
                agent.Move(move);
            }
      
        }
        for (int i = 0; i < agents.Count; i++)
        {
            if (agents[i].getDestroyed() == true)
            {
                agents.RemoveAt(i);        
            }
        }
    }

    List<Transform> getNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c.tag != "Player" || c.tag != "Bullet")
            {
                if (c != agent.AgentCollider)
                {
                    context.Add(c.transform);
                }
            }

        }
        return context;
    }
}
