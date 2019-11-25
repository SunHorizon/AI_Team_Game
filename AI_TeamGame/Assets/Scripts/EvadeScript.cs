using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeScript : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 orientation;
    // Start is called before the first frame update
    void Start()
    {
        orientation = Vector3.up;
    }
    private void EvadeTarget(Vector3 target)
    {
        float dt = Time.deltaTime;

        // To do: Get the direction(dir) pointing to this object from the target.
        // The direction is exactly an opposite direction vector of chasing.
        // The direction should be a unit vector.
        Vector3 dir = gameObject.transform.position - target;

        orientation = dir;
        UpdateOrientation();

        Vector3 pos = transform.position;
        Vector3 velocity = orientation.normalized * speed;
        // To do: Update the current position (pos) using S_final = S_initial + v * t


        pos += velocity * dt;
        transform.position = pos;
    }

    void UpdateOrientation()
    {
        Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(orientation.x, orientation.y) * Mathf.Rad2Deg);
        transform.eulerAngles = angle;
    }
}
