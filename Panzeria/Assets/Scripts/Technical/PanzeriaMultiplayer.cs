using Unity.Netcode;
using UnityEngine;

public class PanzeriaMultiplayer : NetworkBehaviour
{
    [SerializeField] private BulletsList BulletsList;
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
        GameObject bullet = GetBulletFromIndex(bulletIndex);
        GameObject spawnedBullet = Instantiate(bullet, position, rotation);
        NetworkObject spawnedBulletNetwork = spawnedBullet.GetComponent<NetworkObject>();
        spawnedBulletNetwork.Spawn(true);
        spawnedBullet.GetComponent<Rigidbody>().isKinematic = false;
        spawnedBullet.GetComponent<Rigidbody>().AddForce(spawnedBullet.transform.forward * 300f);
    }

    private int GetBulletIndex(GameObject bullet)
    {
        return BulletsList.bullets.IndexOf(bullet);
    }

    private GameObject GetBulletFromIndex(int bulletIndex)
    {
        return BulletsList.bullets[bulletIndex]; ;
    }
}
