using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage,
        range,
        speed,
        distance;

    public void initialize(float d, float r, float s)
    {
        damage = d;
        range = r;
        speed = s;
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmt = speed * Time.deltaTime;
        transform.Translate(0, 0, moveAmt);
        distance += moveAmt;

        if(distance >= range)
        {
            finish();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Character"))
        {
            hit(other.gameObject);
        }
        else if(!other.tag.Equals("Bullet"))
        {
            finish();
        }
    }

    protected virtual void hit(GameObject o)
    {
        //o.GetComponent<CharacterController>().takeDamage(damage);
    }

    protected virtual void finish()
    {
        Destroy(gameObject);
    }
}
