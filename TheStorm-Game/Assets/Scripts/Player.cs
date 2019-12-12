﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public GameObject secondaryWeapon;
    [Header("Player Attributes")]
    public float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopAttack();
        }
    }

    protected override void Move()
    {
        Rotate();
        // PLAYER MOVEMENT //
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(h, 0, v);
        //movement.Normalize();
        //movement *= (speed * Time.deltaTime);

        //transform.Translate(movement);
        //gameObject.transform.position += new Vector3(h, 0, v).normalized * speed;
        gameObject.GetComponentInParent<Transform>().parent.position += new Vector3(h, 0, v).normalized * speed;
    }

    private void Rotate()
    {
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

        if(transform.rotation.eulerAngles.y > 315 || transform.rotation.eulerAngles.y < 45)
        {
            print(gameObject.GetComponentInParent<SpriteRenderer>().sprite);
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingAway;
        }
        else if(transform.rotation.eulerAngles.y > 45 && transform.rotation.eulerAngles.y < 135)
        {
            print(gameObject.GetComponentInParent<SpriteRenderer>().sprite);
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingRight;
        }
        else if(transform.rotation.eulerAngles.y > 135 && transform.rotation.eulerAngles.y < 225)
        {
            print(gameObject.GetComponentInParent<SpriteRenderer>().sprite);
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingFront;
        }
        else
        {
            print(gameObject.GetComponentInParent<SpriteRenderer>().sprite);
            gameObject.GetComponentInParent<SpriteRenderer>().sprite = facingLeft;
        }
        //print(transform.rotation.eulerAngles.y);
    }
}
