using UnityEngine;
using Unity.Netcode;

public class PlayerFireAbility : NetworkBehaviour
{
    public BulletsList BulletsList { get; }

    public PlayerFireAbility(BulletsList bulletsList)
    {
        BulletsList = bulletsList;
    }

    public void UseBombAbility(GameObject player, GameObject ability, Transform spawnPoint)
    {
        PanzeriaMultiplayer.Instance.SpawnBullet(ability, spawnPoint.position, spawnPoint.rotation);
        ResetAbility(player);
    }

    private void ResetAbility(GameObject player) => player.GetComponent<Tank>().ability = null;
}
