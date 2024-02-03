using System.Collections;
using UnityEngine;

public class AbilitySpawner : MonoBehaviour
{
    [SerializeField] private AbilitiesList abilitiesList;
    [SerializeField] private float maxMapWidth;
    [SerializeField] private float minMapWidth;
    [SerializeField] private float maxMapHeight;
    [SerializeField] private float minMapHeight;

    void Start()
    {
        StartCoroutine(SpawnAbilityCoroutine());
    }

    IEnumerator SpawnAbilityCoroutine()
    {
        yield return new WaitForSeconds(20f);
        PanzeriaMultiplayer.Instance.SpawnAbility(abilitiesList.abilities[0], new Vector3(Random.Range(minMapWidth, maxMapWidth), 0, Random.Range(minMapHeight, maxMapHeight)), Quaternion.identity);
        StartCoroutine(this.SpawnAbilityCoroutine());
    }
}
