using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int extraJumps;

    // Start is called before the first frame update
    void Start()
    {
    
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded == true){
            extraJumps = 1;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpforce;
            extraJumps--;

        }
    }

    void FixedUpdate(){
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
}
