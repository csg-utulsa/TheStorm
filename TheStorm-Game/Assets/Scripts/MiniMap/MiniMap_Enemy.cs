using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap_Enemy : MonoBehaviour
{
    private GameObject sphere;
    private GameObject enemy;
    private GameObject mainCamera;
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //this will need to be changed in the final build
        enemy = GameObject.FindGameObjectWithTag("Enemy_Test_Tag");
        
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = enemy.transform.position;
        sphere.GetComponent<Collider>().isTrigger = true;
        sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
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
        sphere.transform.position = enemy.transform.position;
    }
}
