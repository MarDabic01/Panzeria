using UnityEngine;

public class DespawnAbility : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 30f);
    }
}
