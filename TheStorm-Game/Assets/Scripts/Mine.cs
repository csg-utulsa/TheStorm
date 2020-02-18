using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float damage;

    AudioSource audioData;

    private bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(exploded && !audioData.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioData.Play(0);
            collision.gameObject.GetComponentInChildren<Player>().TakeDamage(damage);
            exploded = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            print(gameObject.transform.GetChild(0));
            Destroy(gameObject.transform.GetChild(0).gameObject);
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet") {
            print("Bullet");
            audioData.Play(0);
            Destroy(gameObject);
        }
    }
}
