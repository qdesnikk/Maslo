using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]

public class AnimationPlayer : MonoBehaviour
{
    private Animator _animator;
    private DiePlayer _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<DiePlayer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMove", true);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _animator.SetTrigger("isJump");
        }

        if (!_player.IsAlive)
        {
            _animator.SetTrigger("isDead");
        }
    }
}
