using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PanzeriaMultiplayer : NetworkBehaviour
{
    [SerializeField] private BulletsList BulletsList;
    [SerializeField] private AbilitiesList AbilitiesList;
    [SerializeField] private List<BombListElement> BombsList;
    public static PanzeriaMultiplayer Instance { get; private set; }

    private void Awake()
    {
        BombsList = new List<BombListElement>();
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

    public void SpawnBomb(GameObject bullet, Vector3 position, Quaternion rotation, ulong networkObjectId)
    {
        SpawnBombServerRpc(GetBulletIndex(bullet), position, rotation, networkObjectId);
    }

    [ServerRpc(RequireOwnership = false)]
    public void SpawnBombServerRpc(int bulletIndex, Vector3 position, Quaternion rotation, ulong networkObjectId)
    {
        GameObject spawnedBomb = Instantiate(GetBulletFromIndex(bulletIndex), position, rotation);
        BombsList.Add(new BombListElement {
            Bomb = spawnedBomb,
            NetworkObjectId = networkObjectId
        });
        NetworkObject spawnedBulletNetwork = spawnedBomb.GetComponent<NetworkObject>();
        spawnedBulletNetwork.Spawn(true);
    }

    public void DespawnBomb(ulong networkObjectId)
    {
        DespawnBombServerRpc(networkObjectId);
    }

    [ServerRpc(RequireOwnership = false)]
    public void DespawnBombServerRpc(ulong networkObjectId)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animation>().Play();
        NetworkObject spawnedBulletNetwork = BombsList.Find(elem => elem.NetworkObjectId == networkObjectId).Bomb.GetComponent<NetworkObject>();
        spawnedBulletNetwork.Despawn(true);
        BombsList.RemoveAll(elem => elem.NetworkObjectId == networkObjectId);
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

    private int GetBulletIndex(GameObject bullet)
    {
        return BulletsList.bullets.IndexOf(bullet);
    }

    private GameObject GetBulletFromIndex(int bulletIndex)
    {
        return BulletsList.bullets[bulletIndex]; ;
    }

    private int GetAbilityIndex(GameObject ability)
    {
        return AbilitiesList.abilities.IndexOf(ability);
    }

    private GameObject GetAbilityFromIndex(int abilityIndex)
    {
        return AbilitiesList.abilities[abilityIndex]; ;
    }
}
