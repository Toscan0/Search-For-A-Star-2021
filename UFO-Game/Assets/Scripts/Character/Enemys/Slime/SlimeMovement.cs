using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SlimeManager))]
public class SlimeMovement : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float minVelocity = 4;
    private float maxVelocity = 6;

    private Rigidbody rb;
    private SlimeManager slimeManager;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        slimeManager = GetComponent<SlimeManager>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        slimeManager.Velocity = Movement.RandomVelocity(minVelocity, maxVelocity);

        SetVelocity();
    }

    public void SetVelocity()
    {

        float velocity = slimeManager.Velocity;

        rb.velocity = new Vector3(velocity, 0, velocity);

        // animations
        velocity = Movement.NumberConverter(velocity, minVelocity, maxVelocity, -1, 1);
        var move = new Vector3(velocity, velocity);
        move.Normalize();

        animator.SetFloat("Speed", move.sqrMagnitude);
        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveZ", move.y);
    }

    public void BackgroundCollision()
    {
        float velocity = slimeManager.Velocity;

        if (transform.position.x >= 14.3 || transform.position.x <= -14.3)
        {
            velocity = -velocity;
        }
        if (transform.position.z >= 24.3 || transform.position.z <= -24.3)
        {
            velocity = -velocity;
        }

        slimeManager.Velocity = velocity;

        SetVelocity();
    }

    private void Update()
    {
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
}
