﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovment : MonoBehaviour
{
    public Vector2 target { get; private set; }
    public GameObject hookGo { get; private set; }
    
    public bool isFishOnHook;
    
    public int fishId;
    public int fishSize;
    public int value;
    public int range;

    public Transform area;
    private bool isReachPoint = true;
    
    private float positionX;
    private float positionY;

    private Vector3 ofset;
    private Hook hook;

    void Start()
    {
        ofset = new Vector3(0.14f, -1.1f, 0);
        hookGo = GameObject.FindGameObjectWithTag("Hook");
        area = transform.parent;
        hook = hookGo.GetComponent<Hook>();
    }

    void Update()
    {
        if (gameObject.transform.position == new Vector3(positionX, positionY, 0))
        {
            isReachPoint = true;
        }

        if (isReachPoint)
        {
            positionX = Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
            positionY = Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
            isReachPoint = false;
        }

        float distanceToBait = Vector2.Distance(transform.position, hook.transform.position);

        if(isFishOnHook)
        {
            return;
        }

        if(distanceToBait <= range && hook.baitSize != 0 && hook.isHookInWater)
        {
            target = hookGo.transform.position;
        }
        else
        {
            target = new Vector2(positionX, positionY);
        }

        PointToFishTravel(target);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if (hook.baitSize >= fishSize)
            {
                transform.parent = hookGo.transform;
                transform.position = hookGo.transform.position + ofset;
                hook.isFishOnHook = true;
                isFishOnHook = true;
            }
            hook.baitSize = 0;
        }
    }

    void PointToFishTravel(Vector2 target)
    { 
        transform.position = Vector2.MoveTowards(transform.position, target, 10 * Time.deltaTime);
    }
}
