using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [Header("Melee Attributes")]
    public float swingTime;
    public float swingAngle;

    private bool rightSide;
    private float swingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        if(swingTime > fireRate)
        {
            swingTime = fireRate;
        }
        
        rightSide = true;

        swingSpeed = swingAngle / swingTime;

        transform.Rotate(0, swingAngle / 2, 0);
    }

    protected override void Fire()
    {
        StartCoroutine(Swing());
    }

    private IEnumerator Swing()
    {
        float swungAmount = 0;

        while(swungAmount < swingAngle)
        {
            float swingDelta = swingSpeed * Time.deltaTime;

            if (swingAngle - swungAmount < swingDelta)
            {
                swingDelta = swingAngle - swungAmount;
            }

            swungAmount += swingDelta;

            if (rightSide)
            {
                swingDelta *= -1;
            }

            transform.Rotate(0, swingDelta, 0);

            yield return null;
        }

        rightSide = !rightSide;
    }
}
