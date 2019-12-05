﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //print(h);

        gameObject.transform.position += new Vector3(h, 0, v).normalized * speed;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 hitPoint = hit.point;

            //transform.LookAt(hitPoint);
            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

            Vector3 directionToMouse = (hitPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToMouse);
            lookRotation.x = 0;
            lookRotation.z = 0;
            //lookRotation.SetEulerAngles(0, lookRotation.eulerAngles.y, 0);
            //Quaternion.Euler
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
