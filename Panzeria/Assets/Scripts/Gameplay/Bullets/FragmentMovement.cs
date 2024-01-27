using UnityEngine;
using Unity.Netcode;

public class FragmentMovement : NetworkBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;

    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(this.transform.forward * bulletSpeed);
        Destroy(gameObject, bulletLifetime);
    }
}
