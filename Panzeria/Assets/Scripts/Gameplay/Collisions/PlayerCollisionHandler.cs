using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletsList bulletsList;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "BombAbility": gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.BOMB); break;
        }
    }
}
