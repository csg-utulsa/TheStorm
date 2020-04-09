using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienInfoCanvas : MonoBehaviour
{
    public Alien alien;

    public void Enable()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void TakeAlien()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        alien.PickUp();
    }

    public void ReleaseAlien()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        alien.Release();

    }
}
