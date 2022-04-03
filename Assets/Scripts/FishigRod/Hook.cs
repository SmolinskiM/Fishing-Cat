using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public bool isFishOnHook;
    public bool isHookInWater;
    public int baitSize;

    public FishingRod fishingRod;
    public DistanceJoint2D joint;
    
    private Rigidbody2D rb;
    [SerializeField] private Transform positionRod;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
    }

    void Update()
    {
        if(isHookInWater)
        {
            if (baitSize == 0 && !isFishOnHook && !fishingRod.isHookOnRod)
            {
                transform.position = Vector2.MoveTowards(transform.position, positionRod.position, 20 * Time.deltaTime);
                joint.distance -= 20 * Time.deltaTime;
            }
            else if (baitSize != 0 && !isFishOnHook && Input.GetKey(KeyCode.Mouse0) && !fishingRod.isHookOnRod)
            {
                transform.position = Vector2.MoveTowards(transform.position, positionRod.position, 2.5f * Time.deltaTime);
                joint.distance -= 2.5f * Time.deltaTime;
            }
            else if (isFishOnHook && !fishingRod.isHookOnRod)
            {
                transform.position = Vector2.MoveTowards(transform.position, positionRod.position, 10 * Time.deltaTime);
                joint.distance -= 10 * Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            rb.mass = 0.5f;
            isHookInWater = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            transform.position = positionRod.position;
            rb.mass = 1;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true;
            fishingRod.isHookOnRod = true;
            isHookInWater = false;

        }
    }
}
