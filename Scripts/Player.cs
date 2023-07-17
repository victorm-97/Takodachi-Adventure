using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] public float movepower = 1.0f;
    [SerializeField] public bool active = true;
    [SerializeField] public bool finish = false;
    public bool _camera = true;
    public bool _item = false;
    public float speed = 18;
    public int maxPlatform = 0;
    Animator move;
   // public Transform top_left;
    //public Transform bottom_right;
    public LayerMask ground_layers;
    private Vector2 spawnPoint;


    private Rigidbody2D _playerRigidbody;
    private Collider2D _collider;

    public GameOverScreen GameOverScreen;
    public KeepScore score;

   private void Start()
    {
        SetRpawnPoint(transform.position);
        move = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }
    }
    private void Update()
    {
        var point = score.GetComponent<KeepScore>();

        MovePlayer();
        if(!finish)
        {
            point.Setup();
        }
        if(!active)
        {
            return;
        }


    }

    void FixedUpdate()
    {

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
        //grounded = Physics2D.OverlapArea(top_left.position, bottom_right.position, ground_layers);
        if (Input.GetButton("Jump") && IsGrounded())
        {
            Jump();
        }
        if (movement_vector != Vector2.zero)
        {
            move.SetBool("iswalking", true);
            if (Input.GetKey("a"))
            {
                move.SetFloat("Input_x", -1);
            }
            else if (Input.GetKey("d"))
            {
                move.SetFloat("Input_x", 1);
            }
            move.SetFloat("Input_y", movement_vector.y);
        }
        else
        {
            move.SetBool("iswalking", false);
        }
        //_playerRigidbody.MovePosition(_playerRigidbody.position + movement_vector);
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
       
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() => _playerRigidbody.velocity = new Vector2(movepower, jumpPower);


    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        Vector2 direction_left = -Vector2.one;
        Vector2 direction_right = Vector2.right+Vector2.down;
        float distance = 1.5f;

        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground_layers);
        RaycastHit2D hit_l = Physics2D.Raycast(position, direction_left, distance, ground_layers);
        RaycastHit2D hit_r = Physics2D.Raycast(position, direction_right, distance, ground_layers);
        if (hit.collider != null || hit_l.collider != null || hit_r.collider != null)
        {
            return true;
        }

        return false;

    }

    public void MiniJump()
    {
       _playerRigidbody.velocity = new Vector2(0, jumpPower/2);
    }

    public void Death()
    {
        active = false;
        _collider.enabled = false;
        _camera = false;
        MiniJump();
        

    }

    public void SetRpawnPoint(Vector2 position)
    {
        spawnPoint = position;

    }

    public void Finish()
    {
        _camera = false;
        finish = true;
    }

    public void Respawn()
    {
        
        //yield return new WaitForSeconds(1f) ;
        transform.position = spawnPoint;
        active = true;
        _collider.enabled = true;
        _camera = true;
        MiniJump();
       
    }

  
}