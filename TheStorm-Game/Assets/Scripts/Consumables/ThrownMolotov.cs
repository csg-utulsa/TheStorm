using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownMolotov : MonoBehaviour
{
    public int damageRadius = 1;
    public int damage = 1;

    private int timer = 1;
    private float startTime;
    private AudioSource breakSound;
    private bool hasExploded = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        breakSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasExploded && (startTime + timer < Time.time))
        {
            hasExploded = true;
            breakSound.Play(0);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            //Play Fire Animation

            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, damageRadius);
            int i = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].gameObject.tag == "Player")
                {
                    hitColliders[i].gameObject.GetComponentInChildren<Player>().TakeDamage(damage);
                }
                else if (hitColliders[i].gameObject.tag == "Enemy")
                {
                    hitColliders[i].gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
                i++;
            }
        }

        if (hasExploded && !breakSound.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
