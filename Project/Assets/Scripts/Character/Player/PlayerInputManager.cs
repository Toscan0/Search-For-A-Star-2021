using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(PlayerWeapon))]
[RequireComponent(typeof(PlayerController))]
public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 move;
    private float rot;

    private float shootTimer;

    private PlayerWeapon playerWeapon;
    private PlayerController playerController;
    private PlayerManager playerManager;

    private void Awake()
    {
        playerWeapon = GetComponent<PlayerWeapon>();
        playerController = GetComponent<PlayerController>();
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.up * z;

        float mouseX  = Input.GetAxis("Mouse X");
        playerController.Rotation(mouseX * Time.deltaTime);

        shootTimer += Time.deltaTime;
        if (shootTimer >= playerWeapon.FireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                shootTimer = 0f;
                playerWeapon.Shoot();
            }
        }
    }

    // Especiallized to physics
    private void FixedUpdate()
    {
        playerController.Movement(move);
    }

    
}
