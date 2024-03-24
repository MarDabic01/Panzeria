using System.Collections.Generic;
using UnityEngine;

public class MainMenuTankColorRenderer : MonoBehaviour
{
    [SerializeField] private List<Material> tankFreeMaterials;
    [SerializeField] private List<Material> adElementsMaterials;

    [SerializeField] private MeshRenderer tankTower;
    [SerializeField] private MeshRenderer tankBody;
    [SerializeField] private MeshRenderer tankCannon;
    [SerializeField] private MeshRenderer mine;
    [SerializeField] private MeshRenderer box;
    [SerializeField] private MeshRenderer boxCap;

    private void Awake()
    {
        int index = Random.Range(0, 9);

        tankTower.material = tankFreeMaterials[index];
        tankBody.material = tankFreeMaterials[index];
        tankCannon.material = tankFreeMaterials[index];

        mine.material = adElementsMaterials[index];
        box.material = adElementsMaterials[index];
        boxCap.material = adElementsMaterials[index];
    }
}
