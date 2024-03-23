using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private MeshRenderer tankTower;
    [SerializeField] private MeshRenderer tankBody;
    [SerializeField] private MeshRenderer tankCannon;

    private Material material;

    private void Awake()
    {
        material = new Material(tankTower.material);
        tankTower.material = material;
        tankBody.material = material;
        tankCannon.material = material;
    }

    public void SetPlayerColor(Material material)
    {
        tankTower.material = material;
        tankBody.material = material;
        tankCannon.material = material;
    }
}
