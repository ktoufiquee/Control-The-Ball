using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity += (Vector3.up * bounceForce);
        }
    }
}
