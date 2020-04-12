using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAlienController : MonoBehaviour
{
    public GameObject[] cageLocations;
    public GameObject[] alienCagePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < cageLocations.Length; i++)
        {
            int random = Random.Range(0, alienCagePrefabs.Length);

            Instantiate(alienCagePrefabs[random], cageLocations[i].transform);
        }
    }
}
