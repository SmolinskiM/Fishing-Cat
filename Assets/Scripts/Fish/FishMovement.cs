using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public bool isFishOnHook;

    public Transform area;
    
    [SerializeField] private Hook hook;
    [SerializeField] private Fish fish;

    private bool isReachPoint = true;
    private const int range = 10;
    private const int fishSpeed = 10;
    private float targetPositionX;
    private float targetPositionY;
    
    private Vector2 target;
    
    public Vector2 Target { get { return target; } }


    private void Start()
    {
        hook = FindObjectOfType<Hook>();
        fish = GetComponent<Fish>();
        area = transform.parent;
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

        if(distanceToBait <= range && hook.bait.baitSize != 0 && hook.isHookInWater)
        {
            target = hook.transform.position;
        }
        else
        {
            target = new Vector2(targetPositionX, targetPositionY);
        }

        PointToFishTravel(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if (hook.bait.baitSize >= (int)fish.FishCurrent.fishSize)
            {
                transform.parent = hook.transform;
                transform.position = hook.transform.position + fish.FishCurrent.ofset;
                hook.isFishOnHook = true;
                isFishOnHook = true;
            }
            hook.bait.baitSize = 0;
        }
    }

    private void PointToFishTravel(Vector2 target)
    { 
        transform.position = Vector2.MoveTowards(transform.position, target, fishSpeed * Time.deltaTime);
    }
}
