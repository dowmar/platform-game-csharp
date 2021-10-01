using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elang : Musuh
{
    private Collider2D colltwo;
    protected override void Start()
    {
        base.Start();
        colltwo = GetComponent<Collider2D>();

    }
}
