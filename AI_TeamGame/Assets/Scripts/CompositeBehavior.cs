using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Composite")]
public class CompositeBehavior : FloakBehavior
{

    public FloakBehavior[] behaviors;
    public float[] weights;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock, GameObject player)
    {
        // handle error
        if(weights.Length != behaviors.Length)
        {
            Debug.Log("Wrong Data: "+ name, this);
            return Vector2.zero;
        }

        // set up moves
        Vector2 move = Vector2.zero;
        
        //iterate through behavior
        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 particalMove = behaviors[i].CalculateMove(agent, context, flock, player) * weights[i];

            if (particalMove != Vector2.zero)
            {
                if (particalMove.sqrMagnitude > weights[i] * weights[i])
                {
                    particalMove.Normalize();
                    particalMove *= weights[i];
                }

                move += particalMove;
            }
        }

        return move;
    }
}
