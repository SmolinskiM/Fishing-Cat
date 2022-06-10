using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool isFishOnHook;
    public bool isHookInWater;
    public int baitSize;
    public int baitSizeStart;
    public int rollingUpSpeed;

    public FishingRod fishingRod;
    public DistanceJoint2D joint;
    
    private Rigidbody2D rb;
    [SerializeField] private Transform positionRod;

    void Start()
    {
        baitSize = baitSizeStart;
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        if(isHookInWater)
        {
            if (baitSize == 0 && !isFishOnHook && !fishingRod.isHookOnRod)
            {
                rollingUpSpeed = 20;
                RollingUp(rollingUpSpeed);
                return;
            }

           if (baitSize != 0 && !isFishOnHook && Input.GetKey(KeyCode.Mouse0) && !fishingRod.isHookOnRod)
            {
                rollingUpSpeed = 10;
                RollingUp(rollingUpSpeed);
                return;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            isHookInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
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

    public void RollingUp(int rollingUpSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, positionRod.position, rollingUpSpeed * Time.deltaTime);
        joint.distance -= rollingUpSpeed * Time.deltaTime;
    }
}
