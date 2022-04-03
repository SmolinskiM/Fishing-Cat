﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public float maxPower { get; private set; }
    public float pressTimeStart { get; private set; }
    
    public bool isHookOnRod;
    public bool isThrowable;

    public int money;

    public float maxDistance = 70;
    private readonly float minDistance = 4;
    
    public Hook hook;
    private LineRenderer lr;
    
    [SerializeField] private Transform pointRod;
    [SerializeField] private Transform pointHook;
    [SerializeField] private ShopOpen shopOpen;
    [SerializeField] private Money moneyBag;


    [SerializeField] private Rigidbody2D hookRb;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        money = moneyBag.money;
    }

    void Start()
    {
        isHookOnRod = true;
        maxPower = 5;
    }

    void Update()
    {
        EnableTrowHook();
        moneyBag.money = money;

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void EnableTrowHook()
    {
        if(shopOpen.isShopOpen)
        {
            return;
        }

        if (isHookOnRod && !hook.isFishOnHook)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                pressTimeStart = Time.time;
                isThrowable = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && isThrowable)
            {
                if (hook.baitSize == 0)
                {
                    hook.baitSize = 1;
                }
                TrowHook(Time.time - pressTimeStart);
                pressTimeStart = 0;
                isThrowable = false;
                isHookOnRod = false;
            }
        }
    }

    void TrowHook(float power)
    {
        if (power > maxPower)
        {
            power = maxPower;
        }
        hook.joint.distance = (power / maxPower) * maxDistance;

        if(hook.joint.distance < 4)
        {
            hook.joint.distance = minDistance;
        }

        hookRb.gravityScale = 1;
        hookRb.AddForce(new Vector2(300, 100) * power);
    }

    void DrawRope()
    {
        lr.SetPosition(0, pointRod.position);
        lr.SetPosition(1, pointHook.position);
    }
}