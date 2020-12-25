using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private float offsetX;
    private float offsetZ;

    void Start()
    {
        offsetX = transform.position.x - player.transform.position.x;
        offsetZ = transform.position.z - player.transform.position.z;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offsetX,
            transform.position.y,
            player.transform.position.z + offsetZ);
    }
}
