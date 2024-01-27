using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector3.zero;
        }
    }
}
