using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DirectionNode
{
    [SerializeField] private float timeValue;
    public float TimeValue { get { return timeValue; } set { this.timeValue = value; } }

    [SerializeField] private Vector3 direction;
    public Vector3 DirectionValue { get { return direction; } set { this.direction = value; } }
}
