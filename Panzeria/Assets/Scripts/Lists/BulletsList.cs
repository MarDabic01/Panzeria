using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BulletsList : ScriptableObject
{
    public List<GameObject> bullets;

    public GameObject GetBulletByName(string bulletName)
    {
        return bullets.Find(bullet => bullet.name == bulletName);
    }
}
