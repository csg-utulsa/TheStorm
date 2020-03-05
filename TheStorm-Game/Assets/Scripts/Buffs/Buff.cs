using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public virtual void GiveBuff(){
        print("In base buff");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (this.GetType().Name != "HealthBuff" || (GameObject.Find("Player").GetComponentInChildren<Player>().health != GameObject.Find("Player").GetComponentInChildren<Player>().maxHealth))
            {

                print("Playing Sound");
                GiveBuff();
                audioData.Play(0);

                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            }
        }
    }
}
