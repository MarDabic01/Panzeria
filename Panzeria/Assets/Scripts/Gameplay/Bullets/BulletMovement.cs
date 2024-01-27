using UnityEngine;
using Unity.Netcode;

public class BulletMovement : NetworkBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;

    private Rigidbody rb;
    private Vector3 lastVelocity;
    private float curSpeed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(this.transform.forward * bulletSpeed);
        Destroy(gameObject, bulletLifetime);
    }

    private void LateUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void BounceBullet(Collision collision)
    {
        curSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(curSpeed, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        BounceBullet(collision);
    }
}
