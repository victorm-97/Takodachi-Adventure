using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public FinishPoint finishpoint;
    public GameObject other;
   
    public int count = 0;

    public void Update()
    {
        var check = other.GetComponent<Player>();

        if (!check.active)
        {
            GameOverScreen.Setup(count);
            
        }

        if(check.finish)
        {
            finishpoint.SetupEnd(count);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cookie"))
        {
            Destroy(other.gameObject);
            count += 1;
        }

    }
}
