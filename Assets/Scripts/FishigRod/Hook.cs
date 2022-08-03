using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool isFishOnHook;
    public bool isHookInWater;
    public int rollingUpSpeed;

    public Bait bait;
    public FishingRod fishingRod;
    public DistanceJoint2D joint;
    
    [SerializeField] private GameObject water;
    [SerializeField] private Transform positionRod;

    private string waterTag;
    
    private Rigidbody2D rb;

    private void Start()
    {
        waterTag = water.tag;
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    private void Update()
    {
        if(isHookInWater)
        {
            if (bait.baitSize == 0 && !isFishOnHook && !fishingRod.isHookOnRod)
            {
                rollingUpSpeed = 20;
                RollingUp(rollingUpSpeed);
                return;
            }

           if (bait.baitSize != 0 && !isFishOnHook && Input.GetKey(KeyCode.Mouse0) && !fishingRod.isHookOnRod)
           {
                rollingUpSpeed = 10;
                RollingUp(rollingUpSpeed);
                return;
           }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            isHookInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            transform.position = positionRod.position;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true;
            fishingRod.isHookOnRod = true;
            isHookInWater = false;

        }
    }

    public void RollingUp(float rollingUpSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionRod.position, rollingUpSpeed * Time.deltaTime);
        joint.distance -= rollingUpSpeed * Time.deltaTime;
    }
}
