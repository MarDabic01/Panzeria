using UnityEngine;
using Unity.Netcode;

public class PlayerFireAbility : NetworkBehaviour
{
    public BulletsList BulletsList { get; }
    private float timer = 0.5f;

    public PlayerFireAbility(BulletsList bulletsList)
    {
        BulletsList = bulletsList;
    }

    public void UseBombAbility(GameObject player, GameObject ability, Transform spawnPoint)
    {
        PanzeriaMultiplayer.Instance.SpawnBullet(ability, spawnPoint.position, spawnPoint.rotation);
        ResetAbility(player);
    }

    public void UseMachineGunAbility(GameObject ability, Transform spawnPoint)
    {
        timer += Time.deltaTime;
        if (timer >= 0.4f)
        {
            PanzeriaMultiplayer.Instance.SpawnBullet(ability, spawnPoint.position, spawnPoint.rotation);
            timer = 0f;
        }
    }

    public void UseMineAbility(GameObject player, GameObject ability, Transform spawnPoint)
    {
        PanzeriaMultiplayer.Instance.SpawnBullet(ability, spawnPoint.position, spawnPoint.rotation);
        ResetAbility(player);
    }

    private void ResetAbility(GameObject player) => player.GetComponent<Tank>().ability = null;
}
