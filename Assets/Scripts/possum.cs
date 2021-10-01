using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possum : Musuh
{


    //yep parameter
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;
    [SerializeField] private bool walking = true;
    [SerializeField] private float speed = 5f;

    private bool leftdir;


    private void Start()
    {
        base.Start();
    }

    private void Update()
    {
        //anim.SetBool("Jalan", true);

        
        walk();

    }

    private void walk()
    {
        if(leftdir)

        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1);

        }




        else
        {

            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(1, 1);


        }

    }

    private void OnTriggerEnter2D(Collider2D belok)
    {
        if (belok.gameObject.CompareTag("belok"))
        {
            // if (leftdir)
            // {
            if (leftdir)
            {
                leftdir = false;
            }
            }
            else if(belok.gameObject.CompareTag("belok2"))
             {
            leftdir = true;
             }
       // }else if(belok.gameObject.CompareTag("belok2"))
      //  {
       //     leftdir = true;
        //}
    }
    private void walkright()
    {
    transform.Translate(2 * Time.deltaTime* speed, 0, 0);
    transform.localScale = new Vector3(-1, 1);
}

    private void belok()
    {
        if(transform.position.x > leftCap)
        {

            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(1, 1);


        }
        else if(transform.position.x == rightCap)
        {

            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1);
        }

    }
   private void Move()
    {
        if (leftdir)
        {
            //Test to see if we are beyond the leftCap
            if (transform.position.x > leftCap)
            {
                // make sure sprite is facing right location and if it is not thn face the right direction
                if (transform.localScale.x != 1)
                {

                    transform.localScale = new Vector3(1, 1);
                }

            }
            else
            {
                leftdir = false;
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
            }
            else
            {
                leftdir = true;
            }
        }
    }
}

//Test to see if we are beyond the leftCap
/* if (transform.position.x > leftCap)
 {
     // make sure sprite is facing right location and if it is not thn face the right direction
     if (transform.localScale.x != 1)
     {

         transform.localScale = new Vector3(1, 1);
     }
 }
}*/
/*  if (transform.position.x < rightCap)
             {
                 // make sure sprite is facing right location and if it is not thn face the right direction
                 if (transform.localScale.x != -1)
                 {

                     transform.localScale = new Vector3(-1, 1);
                 }

             }
         }*/