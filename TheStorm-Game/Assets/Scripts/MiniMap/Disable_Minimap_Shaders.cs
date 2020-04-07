using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Minimap_Shaders : MonoBehaviour
{
    private GameObject miniCamera;
    private Shader nullShader;
    void Start()
    {
        nullShader = null;
        miniCamera = GameObject.FindGameObjectWithTag("MiniCamera");
        miniCamera.GetComponent<Camera>().RenderWithShader(nullShader, "nullShader");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
