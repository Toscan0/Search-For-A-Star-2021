using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TargetColision : MonoBehaviour
{
    [SerializeField]
    private bool staticTarget = true;

    private Quaternion targetRotation;
    private AudioSource audiuoSource;

    private void Awake()
    {
        audiuoSource = GetComponent<AudioSource>();    
    }

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audiuoSource.Play();

            if (!staticTarget)
            {
                Quaternion targetDown = Quaternion.Euler(180, targetRotation.y, targetRotation.z);
                transform.rotation = Quaternion.Slerp(targetRotation, targetDown, 1);

                StartCoroutine(TargetUp());
            }
        }
    }

    IEnumerator TargetUp()
    {
        float t = Random.Range(1f, 2.5f);
        yield return new WaitForSeconds(t);

        //The tarhet is down
        Quaternion targetDown = transform.rotation;
        transform.rotation = Quaternion.Slerp(targetRotation, targetRotation, 1);
    }
}
