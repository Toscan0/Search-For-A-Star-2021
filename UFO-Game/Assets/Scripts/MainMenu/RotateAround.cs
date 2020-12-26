using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float angle = 20;

    private void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0, 1f, -0.4f) , angle * Time.deltaTime);
    }
}
