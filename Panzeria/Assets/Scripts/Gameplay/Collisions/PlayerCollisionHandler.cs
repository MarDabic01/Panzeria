using System.Collections;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private BulletsList bulletsList;
    [SerializeField] private GameObject laserSpawnPoint;
    
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "BombAbility": gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.BOMB); break;
            case "MachineGunAbility": {
                    gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.MACHINEGUNBULLET);
                    StartCoroutine(ResetMachineGun());
            } break;
            case "MineAbility": gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.MINE); break;
            case "LaserAbility":
                {
                    laserSpawnPoint.GetComponent<LineRenderer>().enabled = true;
                    laserSpawnPoint.GetComponent<Laser>().enabled = true;
                    gameObject.GetComponent<Tank>().ability = bulletsList.GetBulletByName(BulletsEnum.LASER);
                }
                break;
        }
    }

    private IEnumerator ResetMachineGun()
    {
        yield return new WaitForSeconds(8f);
        gameObject.GetComponent<Tank>().ability = null;
    }
}
