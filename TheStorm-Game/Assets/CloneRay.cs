using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneRay : MonoBehaviour
{
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = line.colorGradient.colorKeys.Length;
    }

    public void setTargets(Vector3 t1, Vector3 t2)
    {
        for(int i = 0; i < line.positionCount; i++)
        {
            line.SetPosition(i, Vector3.Lerp(t1, t2, i / line.positionCount));
        }
    }
}
