using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
