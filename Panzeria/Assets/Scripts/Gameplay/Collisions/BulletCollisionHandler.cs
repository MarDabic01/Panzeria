using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            Destroy(gameObject);
        }
    }
}
