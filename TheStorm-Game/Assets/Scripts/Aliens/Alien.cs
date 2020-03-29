using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Alien class is the base class
/// for controlling the actual Alien.
/// </summary>
public class Alien : MonoBehaviour
{

    /***** Public Variables *****/
    public AlienBuff buff;
    public Sprite sprite;

    /*
     * Currently unimplemented.
     * If there is any common behavior
     * from Aliens that need to happen
     * in Start, put it here.
     */
    protected virtual void Start() {}

    /*
     * Currently unimplemented.
     * If there is any common behavior
     * from Aliens that need to happen
     * in Update, put it here.
     */
    protected virtual void Update() {}

    /// <summary>
    /// Picks up the Alien.
    /// </summary>
    public virtual void PickUp()
    {

        Debug.Log("Picking up Alien");
        ApplyBuff();
        Inventory.instance.AddAlien(buff, sprite);
        Destroy(gameObject);

    }

    public void Release()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Applies the buff associated with
    /// the Alien.
    /// </summary>
    protected virtual void ApplyBuff()
    {
        buff.ApplyBuff();
    }

}
