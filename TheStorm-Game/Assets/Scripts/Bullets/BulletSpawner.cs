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
        Debug.Log("Spawn");
        Vector3 angles = t.eulerAngles;
        angles.y += angle;
        t.eulerAngles = angles;

        GameObject bullet = Instantiate(bulletPrefabsStatic[(int)type], t.position, t.rotation);
        bullet.GetComponent<Bullet>().initialize(damage, range, bulletVelocity);
    }

    public static void Spawn(Transform t, float damage, float range, float bulletVelocity, BulletTypes type)
    {
        GameObject bullet = Instantiate(bulletPrefabsStatic[(int)type], t.position, t.rotation);
        bullet.GetComponent<Bullet>().initialize(damage, range, bulletVelocity);
    }

    public static void Spawn(Transform t, float damage, float range, float bulletVelocity)
    {
        GameObject bullet = Instantiate(bulletPrefabsStatic[0], t.position, t.rotation);
        bullet.GetComponent<Bullet>().initialize(damage, range, bulletVelocity);
    }
}
