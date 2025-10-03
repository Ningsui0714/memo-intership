using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        Move(); //ÒÆ¶¯º¯Êý
    }
    public void Move()
    {
        if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = true;
        if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = false;
    }
}


