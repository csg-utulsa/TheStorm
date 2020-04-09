using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_PlayerDot : MonoBehaviour
{

    private GameObject sphere;
    private GameObject player;
    private GameObject mainCamera;
    private GameObject miniCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        miniCamera = GameObject.FindGameObjectWithTag("MiniCamera");
        
        player = GameObject.FindGameObjectWithTag("Player");
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = player.transform.position;
        sphere.GetComponent<Collider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        sphere.transform.localScale = new Vector3(2, 2, 2);
        sphere.GetComponent<Renderer>().receiveShadows = false;
        sphere.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        // this sets the sphere at layer 10 and culling Mask enables the default layer only
        // if more layers need to be activated the culling mask needs to be changed
        //use https://answers.unity.com/questions/8715/how-do-i-use-layermasks.html for culling mask layer enabling and disabling
        sphere.layer = 10;
        mainCamera.GetComponent<Camera>().cullingMask = 1 << 0;

    }

    // Update is called once per frame
    void Update()
    {
        sphere.transform.position = player.transform.position;
        miniCamera.transform.position = new Vector3(player.transform.position.x, (float)17, player.transform.position.z);
    }
}
