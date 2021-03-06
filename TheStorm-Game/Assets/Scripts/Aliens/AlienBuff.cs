﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AlienBuff is the base class for managing the buffs
/// given by Aliens.
/// </summary>
public class AlienBuff : MonoBehaviour
{

    /***** Public Variables *****/
    public Player player;

    void Start()
    {
        player = GameObject.Find("PlayerChild").GetComponent<Player>();
    }

    /// <summary>
    /// Applies the buff to the player.
    /// Contains common functionality
    /// across the buffs.
    /// </summary>
    public virtual void ApplyBuff()
    {
        Debug.Log("Applying buff");
    }

    public virtual void RemoveBuff()
    {
        print("Removing Buff");
    }
}
