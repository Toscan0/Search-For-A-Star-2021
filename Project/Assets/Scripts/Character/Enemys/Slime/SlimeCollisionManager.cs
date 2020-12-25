using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlimeManager))]
[RequireComponent(typeof(SlimeMovement))]
public class SlimeCollisionManager : MonoBehaviour
{
    private SlimeManager slimeManager;
    private SlimeMovement slimeMovement;

    private void Awake()
    {
        slimeManager = GetComponent<SlimeManager>();
        slimeMovement = GetComponent<SlimeMovement>();
    }


    /*
     * TODO: Change this to script
     */
    private void Update()
    {
        var target = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Rotate to target
        Vector3 relativePos = target - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }



    private void OnCollisionEnter(Collision collision)
    {
        slimeManager.CollisionWithPlayer(collision.gameObject);

        slimeMovement.BackgroundCollision();
    }
}
