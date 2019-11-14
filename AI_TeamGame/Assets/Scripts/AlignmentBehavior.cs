using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FloakBehavior {

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, GameObject player)
    {
        // if no neighobers, stay the current course
        if (context.Count == 0)
        {
            return agent.transform.up;
        }

        // add all the points and average it
        Vector2 AlignmentMove = Vector2.zero;
        foreach (Transform item in context)
        {
            AlignmentMove += (Vector2)item.transform.up;
        }
        AlignmentMove /= context.Count;

        return AlignmentMove;
    }
}
