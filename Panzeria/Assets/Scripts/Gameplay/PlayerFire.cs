using UnityEngine;
using Unity.Netcode;

public class PlayerFire : NetworkBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PanzeriaMultiplayer.Instance.SpawnBullet(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
