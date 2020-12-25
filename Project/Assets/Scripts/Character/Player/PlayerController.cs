using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Range(100, 500)]
    private float rotSpeed = 150;
    [SerializeField]
    [Range(1, 10)]
    private float moveSpeed = 4;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Movement(Vector3 movement)
    {
        rb.MovePosition(gameObject.transform.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void Rotation(float mouseX)
    {
        transform.Rotate(Vector3.back, mouseX * rotSpeed);
    }
}
