using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kodok : Musuh
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLength = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    
    private bool facingLeft = true;

    protected override void Start()
    {
        base.Start();
        coll = GetComponent<Collider2D>();
        
    }
    private void Update()
    {
        //tramsisi dari loncat ke jatuh
        if(anim.GetBool("Loncat"))
        {
            if (rb.velocity.y < .1)
            {
                anim.SetBool("Jatuh", true);
                anim.SetBool("Loncat", false);
            }
        }
        
        //transisi dari jatuh ke loncat
        if(coll.IsTouchingLayers(ground)&& anim.GetBool("Jatuh"))
        {
            anim.SetBool("Jatuh", false);
        }
    }

    private void Move()
    {
        if (facingLeft)
        {
            //Test to see if we are beyond the leftCap
            if (transform.position.x > leftCap)
            {
                // make sure sprite is facing right location and if it is not thn face the right direction
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }


                //test to see if i am on the ground, if so jump
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Loncat", true);
                }
            }
            else
            {
                facingLeft = false;
            }

        }
        else
        {
            if (transform.position.x < rightCap)
            {
                // make sure sprite is facing right location and if it is not thn face the right direction
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }


                //test to see if i am on the ground, if so jump
                if (coll.IsTouchingLayers(ground))
                {
                    //jump
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Loncat", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }
   
}
