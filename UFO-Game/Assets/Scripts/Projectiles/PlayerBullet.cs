using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBullet : Projectile
{
    public GameObject impactEffectPrefab;

    public int Speed { get; set; }

    private Rigidbody rb;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = transform.up * Speed;
    }

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        Quaternion impactEffectRotation = transform.rotation * Quaternion.Euler(90, 90, 0);

        var impactEffect = Instantiate(impactEffectPrefab, 
            transform.position,
            impactEffectRotation);

        Destroy(impactEffect, 0.4f);
    }
}
