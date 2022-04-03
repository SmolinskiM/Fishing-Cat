﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSprite : MonoBehaviour
{
    private FishMovment fishMovment;
    private SpriteRenderer fishSprite;

    private void Start()
    {
        fishMovment = GetComponent<FishMovment>(); 
        fishSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        FlipSprite(fishMovment.target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if(fishMovment.isFishOnHook)
            {
                transform.Rotate(0, 0, -90);
                fishSprite.flipX = false;
            }
        }
    }

    void FlipSprite(Vector2 target)
    {
        if(!fishMovment.isFishOnHook)
        {
            if (target.x < transform.position.x)
            {
                fishSprite.flipX = false;
            }
            else
            {
                fishSprite.flipX = true;
            }
        }
    }
}