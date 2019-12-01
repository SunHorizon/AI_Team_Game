using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseScript : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private string name;
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 orientation;
    [SerializeField] private float angularVelocitiy;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find(name);
        orientation = Vector3.up;
    }
    private void Update()
    {
        ChaseTarget(target.transform.position);
    }
    private void ChaseTarget(Vector3 target_)
    {
        float dt = Time.deltaTime;

        Vector3 dir = target_ - gameObject.transform.position;

        float Dot = Vector3.Dot(dir, orientation);
        float e = Dot / (dir.magnitude * orientation.magnitude);
        float disiredAngle = Mathf.Acos(e) * Mathf.Rad2Deg;
        float accurateAngle = angularVelocitiy * dt;

        if (disiredAngle < accurateAngle)
        {
            orientation = dir.normalized;
        }
        if (disiredAngle > accurateAngle)
        {
            Vector3 normalDir = new Vector3(orientation.y, -orientation.x, 0.0f);

            if (Vector3.Dot(normalDir, dir) > 0.0f)
            {
                accurateAngle = -accurateAngle;
            }
            Vector3 rotatedOrientation = Quaternion.Euler(0, 0, accurateAngle) * orientation.normalized;

            orientation = rotatedOrientation;
        }

        UpdateOrientation();

        Vector3 pos = transform.position;
        Vector3 velocity = orientation.normalized * speed;

        pos += velocity * dt;
        transform.position = pos;
        //Debug.Log("Target position: " + target_);
    }
    void UpdateOrientation()
    {
        Vector3 angle = new Vector3(0, 0, -Mathf.Atan2(orientation.x, orientation.y) * Mathf.Rad2Deg);
        transform.eulerAngles = angle;
    }
}
