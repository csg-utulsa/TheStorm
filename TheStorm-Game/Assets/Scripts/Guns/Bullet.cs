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
        Debug.Log("initialize");
        damage = d;
        range = r;
        speed = s;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveAmt = speed * Time.fixedDeltaTime;
        transform.Translate(0, 0, moveAmt);
        distance += moveAmt;

        if(distance >= range)
        {
            finish();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if(other.tag.Equals("Character"))
        {
            hit(other.gameObject);
        }

        finish();
    }

    protected virtual void hit(GameObject o)
    {
        //o.GetComponent<CharacterController>().takeDamage(damage);
    }

    protected virtual void finish()
    {
        Debug.Log("Finish");
        Destroy(gameObject);
    }
}
