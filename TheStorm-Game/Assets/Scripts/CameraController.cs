using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform mainCamera;
    public Vector3 offset;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;

        mainCamera.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.LookAt(player);
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(mainCamera.position, desiredPosition, speed);
        mainCamera.position = smoothedPosition;
        //mainCamera.rotation = Quaternion.Slerp(mainCamera.rotation, player.rotation, speed * Time.deltaTime);
    }
}
