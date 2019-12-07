using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flock/Behavior/WarBehave")]
public class CompBehaviour2 : FlockBehaviour2
{
    public FlockBehaviour2[] behaviours;

    public float[] weights;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock2 flock)
    {
        /// if data is not the same show where and dont move
        if ( weights.Length != behaviours.Length)
        {
            Debug.Log("data miss match " + name, this);
            return Vector2.zero;
        }
        //set move

        Vector2 move = Vector2.zero;

        //iterate through the behaviours
        for (int i = 0; i < behaviours.Length; i++)
        {
            Vector2 partialMove = behaviours[i].CalculateMove(agent, context, flock) * weights[i];

            if (partialMove != Vector2.zero)
            {
                if (partialMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partialMove.Normalize();
                    partialMove *= weights[i];
                }
                move += partialMove;
            }
        }

        return move;
    }
}


