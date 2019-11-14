﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FloakBehavior {


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
        return cohesionMove;
    }

}