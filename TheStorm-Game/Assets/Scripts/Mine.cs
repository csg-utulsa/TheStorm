using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float damage;

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print(collision.gameObject.GetComponentInChildren<Player>().health);
            audioData.Play(0);
            collision.gameObject.GetComponentInChildren<Player>().TakeDamage(damage);
            Destroy(gameObject);
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
