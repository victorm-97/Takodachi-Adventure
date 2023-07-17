using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask Player_layer;
    private Collider2D _collider;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector2 point = Vector2.up;
        Vector2 position = transform.position;
        float distance = 1.5f;
        _collider = GetComponent<Collider2D>();

        RaycastHit2D hit = Physics2D.Raycast(position, point, distance, Player_layer);
        var player = other.collider.GetComponent<Player>();

        if (hit.collider != null)
        {
            Destroy(this.gameObject);
            player.MiniJump();
        }
        else
            player.Death();
    }
}
