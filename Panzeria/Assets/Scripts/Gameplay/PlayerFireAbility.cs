using UnityEngine;
using Unity.Netcode;

public class PlayerFireAbility : NetworkBehaviour
{
    public BulletsList BulletsList { get; }
    public PlayerFire PlayerFire { get; }

    private GameObject bombLocal;

    private bool isBombFired = false;

    public PlayerFireAbility(BulletsList bulletsList, PlayerFire playerFire)
    {
        BulletsList = bulletsList;
        PlayerFire = playerFire;
    }

    public void UseBombAbility(GameObject player, GameObject ability, Transform spawnPoint)
    {
        if (!isBombFired)
        {
            bombLocal = Instantiate(BulletsList.GetBulletByName(BulletsEnum.BOMBLOCAL), spawnPoint.position, spawnPoint.rotation);
            PanzeriaMultiplayer.Instance.SpawnBomb(ability, spawnPoint.position, spawnPoint.rotation, player.GetComponent<NetworkObject>().NetworkObjectId);
            isBombFired = true;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                PanzeriaMultiplayer.Instance.SpawnBullet(BulletsList.GetBulletByName(BulletsEnum.BOMBFRAGMENT), bombLocal.transform.position, Quaternion.Euler(0f, Random.Range(0, 360), 0f));
            }
            PanzeriaMultiplayer.Instance.DespawnBomb(player.GetComponent<NetworkObject>().NetworkObjectId);
            Destroy(bombLocal);
            isBombFired = false;
        }
    }

    private void ResetAbility() => PlayerFire.ability = null;
}
