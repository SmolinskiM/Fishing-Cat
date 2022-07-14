using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Vector2 Target { get; private set; }
    public GameObject HookGo { get; private set; }
    
    public bool isFishOnHook;

    public Fish fish;
    public Transform area;
    
    private bool isReachPoint = true;
    private int range;
    private int fishSpeed;
    private float targetPositionX;
    private float targetPositionY;

    private Hook hook;

    private void Start()
    {
        fishSpeed = 10;
        range = 10;
        HookGo = GameObject.FindGameObjectWithTag("Hook");
        area = transform.parent;
        hook = HookGo.GetComponent<Hook>();
        
    }

    private void Update()
    {
        if (isFishOnHook)
        {
            return;
        }

        if (transform.position == new Vector3(targetPositionX, targetPositionY, transform.position.z))
        {
            isReachPoint = true;
        }

        if (isReachPoint)
        {
            targetPositionX = Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
            targetPositionY = Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
            isReachPoint = false;
        }

        float distanceToBait = Vector2.Distance(transform.position, hook.transform.position);

        if(distanceToBait <= range && hook.baitSize != 0 && hook.isHookInWater)
        {
            Target = HookGo.transform.position;
        }
        else
        {
            Target = new Vector2(targetPositionX, targetPositionY);
        }

        PointToFishTravel(Target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if (hook.baitSize >= fish.fishSize)
            {
                transform.parent = HookGo.transform;
                transform.position = HookGo.transform.position + fish.ofset;
                hook.isFishOnHook = true;
                isFishOnHook = true;
            }
            hook.baitSize = 0;
        }
    }

    private void PointToFishTravel(Vector2 target)
    { 
        transform.position = Vector2.MoveTowards(transform.position, target, fishSpeed * Time.deltaTime);
    }
}
