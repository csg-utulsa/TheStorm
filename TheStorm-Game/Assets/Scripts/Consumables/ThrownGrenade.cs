using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownGrenade : MonoBehaviour
{
    public int timer = 5;
    public int explosionRadius = 1;
    public int damage = 1;

    private float startTime;
    private AudioSource explosionSound;
    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        explosionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasExploded && (startTime+timer < Time.time))
        {
            hasExploded = true;
            explosionSound.Play(0);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            //Play Explosion Animation

            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "Player")
                {
                    hitColliders[i].gameObject.GetComponentInChildren<Player>().TakeDamage(damage);
                }
                else if(hitColliders[i].gameObject.tag == "Enemy")
                {
                    hitColliders[i].gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
                i++;
            }
        }

        if (hasExploded && !explosionSound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
