using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FightFish : MonoBehaviour
{
    public Transform targetFish;
    public Hook hook;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetFish.position, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Green"))
        {
            hook.fightStatus = "Green";
        }
        else if(collision.CompareTag("Yellow"))
        {
            hook.fightStatus = "Yellow";

        }
        else if(collision.CompareTag("Red"))
        {
            hook.fightStatus = "Red";
        }
    }
}
