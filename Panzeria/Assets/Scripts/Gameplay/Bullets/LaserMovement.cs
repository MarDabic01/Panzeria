using UnityEngine;
using Unity.Netcode;

public class LaserMovement : NetworkBehaviour
{
    [SerializeField] private GameObject laser;

    private Rigidbody rb;
    private Vector3 lastVelocity;
    private float curSpeed;
    private Vector3 direction;
    private float t = 0;
    private bool shouldReflect = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        lastVelocity = rb.velocity;
        if (!shouldReflect)
        {
            t += Time.deltaTime;
            gameObject.transform.localScale = new Vector3(1f, 1f, Mathf.Lerp(1f, 75f, t / 2f));
        }
        else
        {
            t += Time.deltaTime;
            gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 180, gameObject.transform.rotation.z, 1);
            gameObject.transform.localScale = new Vector3(1f, 1f, Mathf.Lerp(gameObject.transform.localScale.z, 0.05f, t / 25f));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log(x);
            shouldReflect = true;
            //gameObject.transform.position = gameObject.GetComponent<LineRenderer>().GetPosition(gameObject.GetComponent<LineRenderer>().positionCount - 1);
        }
    }
}
