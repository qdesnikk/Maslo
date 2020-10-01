using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Knife>(out Knife knife))
        {
           _isAlive = false;
        }
    }
}
