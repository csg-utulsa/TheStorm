using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownMolotov : MonoBehaviour
{
    public int timer = 1;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + timer < Time.time)
        {
            Destroy(gameObject);
        }
    }
}
