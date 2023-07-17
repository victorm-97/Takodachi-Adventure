using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickableType { SCORE, ITEM }

public class Collectable : MonoBehaviour
{

    private void Start()
    {
        Debug.Log("Script is working");
    }

    public void OnCollisonEnter2d(Collision2D collision)
    { 
        Debug.Log("Script is working 2");
    
         Destroy(collision.gameObject);

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Cookie is Destroyed");
                  
        }
    }
}
