using UnityEngine;

public class MineCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletsList bulletsList;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < 7; i++)
            {
                PanzeriaMultiplayer.Instance.SpawnBullet(bulletsList.GetBulletByName(BulletsEnum.BOMBFRAGMENT), gameObject.transform.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
            }
            Destroy(gameObject);
        }
    }
}
