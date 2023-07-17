﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishcheck : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Player>();

        if (player != null)
        {
            player.Finish();
        }
    }
}
