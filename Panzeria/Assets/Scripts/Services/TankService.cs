using UnityEngine;
using Unity.Netcode;

public class TankService : NetworkBehaviour, ITank
{
    public void MoveTank(float input, float moveSpeed, Rigidbody rigidbody)
    {
        Vector3 moveDirection = rigidbody.transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + moveDirection);
    }

    public void RotateTank(float input, float rotationSpeed, Rigidbody rigidbody)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rigidbody.MoveRotation(rigidbody.rotation * turnRotation);
    }

    public void RotateWheels(float moveInput, float rotationInput, float wheelRotationSpeed, GameObject[] leftWheels, GameObject[] rightWheels)
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;

        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }

        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    public void FireBasicBullet(BulletsList bulletsList, Transform spawnPoint)
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PanzeriaMultiplayer.Instance.SpawnBullet(bulletsList.GetBulletByName(BulletsEnum.BULLET), spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void FireAbility(GameObject ability, PlayerFireAbility playerFireAbility, BulletsList bulletsList, Transform spawnPoint)
    {
        if (Input.GetKeyDown(KeyCode.P) && doesUserHaveAbility(ability))
        {
            switch (ability.name)
            {
                case BulletsEnum.BOMB: playerFireAbility.UseBombAbility(bulletsList.GetBulletByName(BulletsEnum.BOMB), spawnPoint); break;
            }
        }
    }

    private bool doesUserHaveAbility(GameObject ability)
    {
        return ability != null ? true : false;
    }
}
