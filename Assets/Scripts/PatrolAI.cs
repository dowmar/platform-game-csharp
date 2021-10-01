using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : Musuh
{
    [HideInInspector]
    public bool movingleft = true;
    public float walkSpeed;
    public float distance;
    public Rigidbody2D rb3;
    private bool startTurn;
    public Transform groundCheckpos;
    public LayerMask groundLayer;


    private void Start()
    {
        base.Start();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheckpos.position, Vector2.down,distance,LayerMask.GetMask("Ground"));
        if (groundInfo.collider == false)
        {
            if(movingleft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingleft = false;
            }else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingleft = true;
            }
        }
    }
}
    