using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float speed;

    protected virtual void attack() { }
    protected virtual void takeDamage(int damage) { }
}
