using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [Header("Gun Attributes")]
    //Angle bullets can deviate from straight
    public float inaccuracy;
    //How long bullets from this gun will travel in seconds
    public float range;
    [Header("Bullet Attributes")]
    //How fast bullets from this gun travel
    public float bulletVelocity;
    //What type of bullet is shot from this gun
    public BulletTypes bulletType;

    private AudioSource audioData;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Called periodically while the trigger is held
    /// Based on the fire rate of the gun
    /// </summary>
    protected override void Fire()
    {
        SpawnBullet();

        if(audioData != null)
        {
            audioData.Play(0);
        }
    }

    /// <summary>
    /// Spawns a bullet using the attributes defined in editor
    /// </summary>
    protected virtual void SpawnBullet()
    {
        float offset = Random.Range(-inaccuracy / 2, inaccuracy / 2);
        
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, offset, ownerTag);
    }

    /// <summary>
    /// Spawns a bullet with a specific Bullet Type
    /// </summary>
    /// <param name="bt">The bullet Type of the spawned bullet</param>
    protected virtual void Fire(BulletTypes bt)
    {
        float offset = Random.Range(-inaccuracy / 2, inaccuracy / 2);

        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bt, offset, ownerTag);
    }

    /// <summary>
    /// Spawns a bullet at the given angle
    /// </summary>
    /// <param name="angle">The angle of the bullet in degrees from forward</param>
    protected virtual void SpawnBullet(float angle)
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bulletType, angle, ownerTag);
    }

    /// <summary>
    /// Spawns a bullet with both a given type and angle
    /// </summary>
    /// <param name="bt">Type of the spawned bullet</param>
    /// <param name="angle">Angle of the spawned bullet in degrees from forward</param>
    protected virtual void SpawnBullet(BulletTypes bt, float angle)
    {
        BulletSpawner.Spawn(transform, damage, range, bulletVelocity, bt, angle, ownerTag);
    }
}
