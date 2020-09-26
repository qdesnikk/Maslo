using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float _speed = 2;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;

    private Rigidbody2D _rigidbody2D;
    private bool isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Movement(-1);

        if (Input.GetKey(KeyCode.D))
            Movement(1);

        if (Input.GetKey(KeyCode.Space))
            Jump();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    }

    private void Movement(float direction)
    {
        _rigidbody2D.transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
        transform.localScale = new Vector3(direction * 1, transform.localScale.y, 1);
    }

    private void Jump()
    {
        if (isGrounded)
            _rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
