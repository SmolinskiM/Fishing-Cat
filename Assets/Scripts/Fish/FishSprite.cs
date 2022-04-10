using System.Collections;
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
        //transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(fishMovment.target.y - transform.position.y, fishMovment.target.x - transform.position.x) * 2 * Mathf.PI);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if(fishMovment.isFishOnHook)
            {
                transform.eulerAngles = new Vector3(0, 0, -90);
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
