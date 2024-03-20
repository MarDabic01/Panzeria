using UnityEngine;
using Unity.Netcode;

public class LaserMovementTEST : NetworkBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;
    public LayerMask layerMask;

    private float t = 0;
    private bool shouldReflect = false;

    private void Update()
    {
        t += Time.deltaTime;
        gameObject.transform.localScale = new Vector3(0.1f, 0.1f, Mathf.Lerp(1f, 75f, t / 2f));
        //if (!shouldReflect)
        //{
        //    t += Time.deltaTime;
        //    gameObject.transform.localScale = new Vector3(1, 1, Mathf.Lerp(1f, 75f, t / 2f));
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Wall")
    //    {
    //        Debug.Log("Reflect laser");
    //        shouldReflect = true;
    //    }
    //}
}
