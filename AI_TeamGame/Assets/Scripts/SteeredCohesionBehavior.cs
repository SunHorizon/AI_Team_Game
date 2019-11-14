using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/SteeredCohesionBehavior")]
public class SteeredCohesionBehavior : FloakBehavior
{

    private Vector2 currentVelocity = Vector2.zero;
    public float agentSmoothTime = 0.5f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, GameObject player)
    {
        // if no neighobers, return nothing
        if (context.Count == 0)
        {
            return Vector2.zero;
        }
        // add all the points and average it
        Vector2 cohesionMove = Vector2.zero;
        foreach (Transform item in context)
        {
            cohesionMove += (Vector2)item.position;
        }
        cohesionMove /= context.Count;

        cohesionMove -= (Vector2)agent.transform.position;
        cohesionMove = Vector2.SmoothDamp(agent.transform.up, cohesionMove, ref currentVelocity, agentSmoothTime, 5f, Time.deltaTime);
        
        return cohesionMove;
    }
}
