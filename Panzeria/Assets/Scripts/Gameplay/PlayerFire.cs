using UnityEngine;
using Unity.Netcode;

public class PlayerFire : NetworkBehaviour
{
    [SerializeField] public BulletsList bulletsList;
    [SerializeField] public GameObject ability;
    [SerializeField] public Transform spawnPoint;

    public PlayerFireAbility playerFireAbility { get; set; }

    void Start()
    {
        playerFireAbility = new PlayerFireAbility(bulletsList, this);
    }

    void Update()
    {
        if (!IsOwner) return;

        FireBasicBullet();
        FireAbility();
    }

    private void FireBasicBullet()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PanzeriaMultiplayer.Instance.SpawnBullet(bulletsList.GetBulletByName(BulletsEnum.BULLET), spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void FireAbility()
    {
        //if (Input.GetKeyDown(KeyCode.P) && doesUserHaveAbility())
        //{
        //    switch (ability.name)
        //    {
        //        case BulletsEnum.BOMB: playerFireAbility.UseBombAbility(bulletsList.GetBulletByName(BulletsEnum.BOMB), spawnPoint); break;
        //    }
        //}
    }

    private bool doesUserHaveAbility()
    {
        return ability != null ? true : false;
    }
}
