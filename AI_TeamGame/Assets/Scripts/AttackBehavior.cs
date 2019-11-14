using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/AttackBehavior")]
public class AttackBehavior : FloakBehavior
{


    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, GameObject player)
    {
        // if no neighobers, return nothing
        if (context.Count == 0)
        {
            return Vector2.zero;
        }
        // add all the points and average it
        Vector2 cohesionMove = Vector2.zero;
        if (player)
        {
            cohesionMove = (player.transform.position - agent.transform.position).normalized;
        }      
        return cohesionMove;
    }
}
