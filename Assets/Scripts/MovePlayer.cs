using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _whatIsGround;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            Move(Direction.MoveLeft.GetHashCode());

        if (Input.GetKey(KeyCode.D))
            Move(Direction.MoveRight.GetHashCode());

        if (Input.GetKey(KeyCode.Space))
            Jump();

        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
    }

    private enum Direction
    {
        MoveRight = 1,
        MoveLeft = -1,
    }

    private void Move(int direction)
    {
        _rigidbody2D.transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
        transform.localScale = new Vector3(direction, transform.localScale.y, 1);
    }

    private void Jump()
    {
        if (_isGrounded)
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}
