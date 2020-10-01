using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _dumping;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 2f);

    private Vector3 _targetPosition;
    private bool _isLeft;
    private float _lastX;

    private void Start()
    {
        _lastX = Mathf.RoundToInt(_player.position.x);
    }

    private void Update()
    {
        CheckDirection();

        if (_isLeft)
            _targetPosition = new Vector3(_player.position.x - _offset.x, _player.position.y + _offset.y, transform.position.z);
        else
            _targetPosition = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);

        Vector3 currentPosition = Vector3.Lerp(transform.position, _targetPosition, _dumping * Time.deltaTime);
        transform.position = currentPosition;
    }

    private void CheckDirection()
    {
        int currentX = Mathf.RoundToInt(_player.position.x);

        if (currentX > _lastX)
            _isLeft = false;
        else if (currentX < _lastX)
            _isLeft = true;

        _lastX = Mathf.RoundToInt(_player.position.x);
    }
}
