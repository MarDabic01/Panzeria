using UnityEngine;

public class FragmentCollisionHandler : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            HandleFragmentWallHit();
        }
    }

    private void HandleFragmentWallHit()
    {
        rb.velocity = Vector3.zero;
        rb.freezeRotation = true;
        rb.GetComponent<BoxCollider>().enabled = false;
    }
}
