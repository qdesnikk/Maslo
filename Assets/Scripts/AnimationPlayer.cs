using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AnimationPlayer : MonoBehaviour
{
    private Animator _animator;
    private MovementPlayer _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<MovementPlayer>();
    }

    void Start()
    {

    }

    void Update()
    {
        if (_player.IsMoving)
        {
            _animator.SetBool("isMove", true);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        Debug.Log(_player.IsMoving);
        if (_player.IsJumping)
        {
            _animator.SetTrigger("isJump");
        }
    }
}
