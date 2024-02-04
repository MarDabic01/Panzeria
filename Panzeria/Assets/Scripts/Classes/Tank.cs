using UnityEngine;
using Unity.Netcode;

public sealed class Tank : NetworkBehaviour
{
    //Initialize variables inside Unity
    //Movement variables
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject[] leftWheels;
    [SerializeField] private GameObject[] rightWheels;
    [SerializeField] private float wheelRotationSpeed;

    //Fire variables
    [SerializeField] public BulletsList bulletsList;
    [SerializeField] public GameObject ability;
    [SerializeField] public Transform spawnPoint;

    //Private variables
    private TankService tankService = new TankService();
    private PlayerFireAbility playerFireAbility;
    private new Rigidbody rigidbody;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        playerFireAbility = new PlayerFireAbility(bulletsList);
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsOwner) return;

        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        tankService.RotateWheels(moveInput, rotationInput, wheelRotationSpeed, leftWheels, rightWheels);
        tankService.FireBasicBullet(bulletsList, spawnPoint);
        tankService.FireAbility(player, ability, playerFireAbility, bulletsList, spawnPoint);
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        tankService.MoveTank(moveInput, moveSpeed, rigidbody);
        tankService.RotateTank(rotationInput, rotationSpeed, rigidbody);
    }
}
