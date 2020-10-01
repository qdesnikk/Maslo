using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Coin))]

public class CollectCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
