using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        var go = collision.gameObject;

        if (go.CompareTag("Player") || go.CompareTag("Enemy"))
        {
            go.GetComponentInChildren<Character>().TakeDamage(damage);
        }
    }
}
