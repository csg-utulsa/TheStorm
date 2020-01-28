using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float resetTime;
    public int score;

    public void TargetHit()
    {
        FindObjectOfType<Inventory>().UpdateScore(score);
        Transform targetTrans = GetComponentInChildren<RectTransform>().transform;
        targetTrans.Rotate(110, 0, 0);
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(TargetReset());

    }

    IEnumerator TargetReset()
    {
        yield return new WaitForSeconds(resetTime);

        Transform targetTrans = GetComponentInChildren<RectTransform>().transform;
        targetTrans.Rotate(-110, 0, 0);
        this.GetComponent<BoxCollider>().enabled = true;
    }

   /* public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Target has been hit");
    } */
}
