using UnityEngine;

public interface ITank
{
    void MoveTank(float input, float moveSpeed, Rigidbody rigidbody);
    void RotateTank(float input, float rotationSpeed, Rigidbody rigidbody);
    void RotateWheels(float moveInput, float rotationInput, float wheelRotationSpeed, GameObject[] leftWheels, GameObject[] rightWheels);
    void FireBasicBullet(BulletsList bulletsList, Transform spawnPoint);
    void FireAbility(GameObject player, GameObject ability, PlayerFireAbility playerFireAbility, BulletsList bulletsList, Transform spawnPoint);
}
