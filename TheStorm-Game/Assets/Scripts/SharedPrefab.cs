using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedPrefab : MonoBehaviour
{
    //public static bool initialized = false;
    // Start is called before the first frame update
    void Start()
    {
        //if (!initialized)
        //{
            DontDestroyOnLoad(this.gameObject);
        //    initialized = true;
        //}
        //else
       // {
       //     Destroy(this.gameObject);
        //}
    }
}
