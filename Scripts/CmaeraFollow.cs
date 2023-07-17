using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmaeraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2, -10);
    public float smoothTime = 0.25f;
    Vector3 currentVelocity;
    public GameObject otherGameObject;


    private void LateUpdate()
    {
        var player = otherGameObject.GetComponent<Player>();
        bool check = player._camera;
        if (check)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                target.position + offset,
                ref currentVelocity,
                smoothTime
                );
        }
   
        
    }
}
