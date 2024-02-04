using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PanzeriaMultiplayer : NetworkBehaviour
{
    [SerializeField] private BulletsList BulletsList;
    [SerializeField] private AbilitiesList AbilitiesList;
    public static PanzeriaMultiplayer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnBullet(GameObject bullet, Vector3 position, Quaternion rotation)
    {
        SpawnBulletServerRpc(GetBulletIndex(bullet), position, rotation);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnBulletServerRpc(int bulletIndex, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedBullet = Instantiate(GetBulletFromIndex(bulletIndex), position, rotation);

        NetworkObject spawnedBulletNetwork = spawnedBullet.GetComponent<NetworkObject>();
        spawnedBulletNetwork.Spawn(true);
    }

    public void BombExplode()
    {
        BombExplodeServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void BombExplodeServerRpc()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>().Play();
    }

    public void SpawnAbility(GameObject ability, Vector3 position, Quaternion rotation)
    {
        SpawnAbilityServerRpc(GetAbilityIndex(ability), position, rotation);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnAbilityServerRpc(int abilityIndex, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedAbility = Instantiate(GetAbilityFromIndex(abilityIndex), position, rotation);

        NetworkObject spawnedAbilityNetwork = spawnedAbility.GetComponent<NetworkObject>();
        spawnedAbilityNetwork.Spawn(true);
    }

    private int GetBulletIndex(GameObject bullet) => BulletsList.bullets.IndexOf(bullet);
    private GameObject GetBulletFromIndex(int bulletIndex) => BulletsList.bullets[bulletIndex];
    private int GetAbilityIndex(GameObject ability) => AbilitiesList.abilities.IndexOf(ability);
    private GameObject GetAbilityFromIndex(int abilityIndex) => AbilitiesList.abilities[abilityIndex]; 
}
