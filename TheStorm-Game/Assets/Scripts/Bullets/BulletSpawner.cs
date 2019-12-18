using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Data type holding the possible bullet types
public enum BulletTypes
{
    Normal = 0,
    Explosive = 1,
    Fire = 2,
    Electric = 3,
    Ice = 4
}

public class BulletSpawner : MonoBehaviour
{
    //Holds all the prefabs for different bullet types, can be set in editor
    public GameObject[] bulletPrefabs;

    //Static array holding the prefabs, can't be set in editor
    private static GameObject[] bulletPrefabsStatic;

    private void Start()
    {
        //Converts the prefabs set in the editor to static
        bulletPrefabsStatic = bulletPrefabs;
    }

    /// <summary>
    /// Spawns a bullet of the given type with the given attributes
    /// </summary>
    /// <param name="t">Transform from which to spawn</param>
    /// <param name="damage">Base damage of the bullet</param>
    /// <param name="range">Range of the bullet</param>
    /// <param name="bulletVelocity">Speed of the bullet</param>
    /// <param name="type">The type of bullet to spawn</param>
    /// <param name="angle">The degrees from straight to rotate the bullet</param>
    public static void Spawn(Transform t, float damage, float range, float bulletVelocity, BulletTypes type, float angle, string tag)
    {
        Quaternion temp = t.rotation;
        //If the bullet is not shooting straight
        if(angle != 0)
        {
            //Adjust the rotation of the bullet
            Vector3 angles = temp.eulerAngles;
            angles.y += angle;
            temp.eulerAngles = angles;
        }
        //Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefabsStatic[(int)type], t.position, temp);

        Debug.Log(tag);
        //Initialize the bullet's values
        bullet.GetComponent<Bullet>().initialize(damage, range, bulletVelocity, tag);
    }
}
