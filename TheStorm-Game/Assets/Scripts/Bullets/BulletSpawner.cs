using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletTypes
{
    Normal = 0,
    Explosive = 1,
    Fire = 2,
    Poison = 3,
    Ice = 4
}

public class BulletSpawner : MonoBehaviour
{
    public GameObject[] bulletPrefabs;

    private static GameObject[] bulletPrefabsStatic;

    private void Start()
    {
        bulletPrefabsStatic = bulletPrefabs;
    }

    public static void Spawn(Transform t, float damage, float range, float bulletVelocity, BulletTypes type, float angle)
    {
        Quaternion temp = t.rotation;

        if(angle != 0)
        {
            Vector3 angles = temp.eulerAngles;
            angles.y += angle;
            temp.eulerAngles = angles;
            Debug.Log($"Angle: {angle}");
        }
        Debug.Log(temp.eulerAngles.y);
        GameObject bullet = Instantiate(bulletPrefabsStatic[(int)type], t.position, temp);
        bullet.GetComponent<Bullet>().initialize(damage, range, bulletVelocity);
    }
}
