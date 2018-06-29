/*
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Walking : MonoBehaviour {
    public float speed;
    public float area;
    private Vector2 newWayPoint;
    private Vector3 wayPoint;
    private Vector3 oldWayPoint;
    public float timeSmooth;
    private float time;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        newWayPoint = Random.insideUnitCircle * area;
        wayPoint = new Vector3(newWayPoint.x, transform.position.y, newWayPoint.y);
        controller = GetComponent<CharacterController>();
        oldWayPoint = wayPoint;
    }

    // Update is called once per frame
    public void Update()
    {
        SailRandomly();
    }

    void SailRandomly()
    {
        Vector3 smoothLookAt = Vector3.Slerp(oldWayPoint, wayPoint, time / timeSmooth);
        smoothLookAt.y = wayPoint.y;
        
        if (Vector3.Distance(transform.position, wayPoint) > 20.0f && time / timeSmooth < 1.0f)
        {
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
        }
        else
        {
            newWayPoint = Random.insideUnitCircle * area;
            oldWayPoint = wayPoint;
            wayPoint = new Vector3(newWayPoint.x, wayPoint.y, newWayPoint.y);
            transform.LookAt(smoothLookAt);
            controller.SimpleMove(transform.forward * speed);
            time = 0;
        }
    }
}
*/
//----------------------------------------------------------------------------
//                              NEW IDEA
//----------------------------------------------------------------------------
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float CircleRadius = 1;
    public float TurnChance = 0.05f;
    public float MaxRadius = 5;

    public float Mass = 15;
    public float MaxSpeed = 3;
    public float MaxForce = 15;

    private Vector3 velocity;
    private Vector3 wanderForce;
    private Vector3 target;

    private void Start()
    {
        velocity = Random.onUnitSphere;
        wanderForce = GetRandomWanderForce();
    }

    private void Update()
    {
        var desiredVelocity = GetWanderForce();
        desiredVelocity = desiredVelocity.normalized * MaxSpeed;

        var steeringForce = desiredVelocity - velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);
        steeringForce /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steeringForce, MaxSpeed);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);
    }

    private Vector3 GetWanderForce()
    {
        if (transform.position.magnitude > MaxRadius)
        {
            var directionToCenter = (target - transform.position).normalized;
            wanderForce = velocity.normalized + directionToCenter;
        }
        else if (Random.value < TurnChance)
        {
            wanderForce = GetRandomWanderForce();
        }

        return wanderForce;
    }

    private Vector3 GetRandomWanderForce()
    {
        var circleCenter = velocity.normalized;
        var randomPoint = Random.insideUnitCircle;

        var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
        displacement = Quaternion.LookRotation(velocity) * displacement;

        var wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}