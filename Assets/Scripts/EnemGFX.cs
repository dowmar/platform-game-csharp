using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemGFX : Musuh
{
    public AIPath aipath;
    private Collider2D cld;

    protected void Start()
    {
        
        base.Start();
        cld = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }else if(aipath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
