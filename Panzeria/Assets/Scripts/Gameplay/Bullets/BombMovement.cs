using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class BombMovement : NetworkBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;
    [SerializeField] int numberOfFragments;
    [SerializeField] BulletsList bulletsList;

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
        StartCoroutine(ExplodeBombEnumerator());
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

    private void BombExplode()
    {
        for (int i = 0; i < numberOfFragments; i++)
        {
            PanzeriaMultiplayer.Instance.SpawnBullet(bulletsList.GetBulletByName(BulletsEnum.BOMBFRAGMENT), gameObject.transform.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
        }
        PanzeriaMultiplayer.Instance.BombExplode();
        Destroy(gameObject);
    }

    IEnumerator ExplodeBombEnumerator()
    {
        yield return new WaitForSeconds(bulletLifetime);
        BombExplode();
    }
}
