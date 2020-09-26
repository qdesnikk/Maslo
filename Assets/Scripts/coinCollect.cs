using System.Collections;
using System.Collections.Generic;
//using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;

public class coinCollect : MonoBehaviour
{
    [SerializeField] private Image[] coins;

    private int currentCoin = 0;
    private Collider2D collision;
    private UnityEngine.Object explosion;
    void Start()
    {
        collision = GetComponent<Collider2D>();
        explosion = Resources.Load("explosion");
        //coins[0].color = new Color(1f, 1f, 1f, 0.5f);
        //coins[1].color = new Color(1f, 1f, 1f, 1f);
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {
            if (currentCoin < coins.Length)
            {
                coins[currentCoin].color = new Color(1f, 1f, 1f, 1f);
                currentCoin++;
                Destroy(collision.gameObject);
            }
            GameObject explosionRef = (GameObject)Instantiate(explosion);
            explosionRef.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);

        }
    }
}