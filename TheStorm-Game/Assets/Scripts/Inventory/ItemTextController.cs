using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTextController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
