using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{

    public bool isHookOnRod;
    public bool isThrowable;

    public float maxDistance = 70;
    
    public Hook hook;
    
    private float pressTimeStart;
    private readonly float maxPower = 5;
    private readonly float minDistance = 4;
    
    private LineRenderer lr;
    private static FishingRod instance;
    
    public float MaxPower { get { return maxPower; } }
    public float PressTimeStart { get { return pressTimeStart; } }
    public static FishingRod Instance { get { return instance; } }
    
    
    [SerializeField] private Transform pointRod;
    [SerializeField] private Transform pointHook;
    [SerializeField] private Money moneyBag;
    [SerializeField] private ShopOpen shopOpen;
    [SerializeField] private CatalogMeneger catalogMeneger;


    [SerializeField] private Rigidbody2D hookRb;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        lr = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        isHookOnRod = true;
    }

    private void Update()
    {
        EnableTrowHook();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void EnableTrowHook()
    {
        if(shopOpen.isShopOpen)
        {
            isThrowable = false;
            return;
        }

        if(catalogMeneger.isEnableToOpen)
        {
            isThrowable = false;
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
                if (hook.bait.baitSize == 0)
                {
                    hook.bait.baitSize = hook.bait.baitSizeStart;
                }
                TrowHook(Time.time - PressTimeStart);
                pressTimeStart = 0;
                isThrowable = false;
                isHookOnRod = false;
            }
        }
    }

    private void TrowHook(float power)
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

    private void DrawRope()
    {
        lr.SetPosition(0, pointRod.position);
        lr.SetPosition(1, pointHook.position);
    }
}
