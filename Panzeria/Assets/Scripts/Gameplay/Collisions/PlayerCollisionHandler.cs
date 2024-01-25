using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "CubeTEST")
        {
            Debug.Log("Collision ended");
            rb.velocity = Vector3.zero;
        }
    }
}
