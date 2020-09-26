using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private Animator anim;
    //private Collision2D col;
    private bool isAlive = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        //col = GetComponent<Collision2D>();
    }

    void Update()
    {
        
    }
 /*   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead" && isAlive == true)
        {
            anim.SetTrigger("Dead");
            Debug.Log("213");
            isAlive = false;
        }
    }*/
    void OnParticleCollision(GameObject collision)
    {
        if(collision.tag == "Fire")
        {
            if (isAlive == true)
            {
                anim.SetTrigger("isDead");
            }
        }

        isAlive = false;
    }
}
