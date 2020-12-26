using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    [SerializeField]
    private float angle;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * angle, 0, Space.World);
    }
}
