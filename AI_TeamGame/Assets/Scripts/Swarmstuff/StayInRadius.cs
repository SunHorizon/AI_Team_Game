using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/stay in radius")]
public class StayInRadius : FlockBehaviour2
{

    Vector2 center;
    public float radius = 6;

   

   

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock2 flock)
    {
        Vector2 centerOffset = center - (Vector2)agent.transform.position;
        float t = centerOffset.magnitude / radius;
        if (t < 0.9)
        {
            return Vector2.zero;
        }
        return centerOffset * t * t;
    }
}
