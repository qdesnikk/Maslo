using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 1f;
    float move;
    float prevPosY;
    static public bool isGrounded;
    private bool inAir;
    private Rigidbody2D rb;
    private Animator anim;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void LeftButtonDown()
    {
        move = -speed;
        transform.localScale = new Vector3(-1, transform.localScale.y, 1);
        anim.SetBool("isMove", true);
    }
    public void RightButtonDown()
    {
        move = speed;
        transform.localScale = new Vector3(1, transform.localScale.y, 1);
        anim.SetBool("isMove", true);
    }
    public void StopMove()
    {
        move = 0;
        anim.SetBool("isMove", false);
    }
    public void OnClickJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("isJump");
        }
    }
    void FixedUpdate()
    {
        transform.Translate(transform.right * move * Time.fixedDeltaTime);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    private void Update()
    {
        if (isGrounded == false)
        {
            inAir = true;
        }
        if (inAir == true && isGrounded == true)
        {
            anim.SetTrigger("isLanding");
            inAir = false;
        }

    }
    /*   private void OnCollisionEnter2D(Collision2D collision)
       {
           if (collision.gameObject.tag == "Something")
           {
               if (transform.position.y > prevPosY)
               {
                   anim.SetTrigger("isLanding");
               }
               isSmth = true;
           }
       }
       private void OnCollisionExit2D(Collision2D collision)
       {
           if (collision.gameObject.tag == "Something")
           {
               isSmth = false;
           }
       }
   */
}
