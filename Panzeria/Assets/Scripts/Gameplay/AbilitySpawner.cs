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
        yield return new WaitForSeconds(10f);
        int abilityIndex = Random.Range(0, 2);
        PanzeriaMultiplayer.Instance.SpawnAbility(abilitiesList.abilities[abilityIndex], new Vector3(Random.Range(minMapWidth, maxMapWidth), 0, Random.Range(minMapHeight, maxMapHeight)), Quaternion.identity);
        StartCoroutine(this.SpawnAbilityCoroutine());
    }
}
