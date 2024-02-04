using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletsList bulletsList;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "BombAbility": gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.BOMB); break;
            case "MachineGunAbility": {
                    gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.MACHINEGUNBULLET);
                    StartCoroutine(ResetMachineGun());
            } break;
        }
    }

    private IEnumerator ResetMachineGun()
    {
        yield return new WaitForSeconds(8f);
        gameObject.GetComponent<Tank>().ability = null;
    }
}
