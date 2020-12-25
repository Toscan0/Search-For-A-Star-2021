using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField]
    private GameObject fadeIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fadeIn.SetActive(true);
        }
    }
}
