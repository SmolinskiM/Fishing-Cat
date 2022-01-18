using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameObject @object;
    public int bait_size;
    public bool fish_on_hook;
    Rigidbody2D rb;
    DistanceJoint2D joint;
    public Rigidbody2D rb_rod;
    public Transform rod_position;
    public Fishing_Rod fishing_rod;

    Fish fish;
    public string fightStatus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(bait_size == 0 && !fish_on_hook)
        {
            transform.position = Vector2.MoveTowards(transform.position, rod_position.position, 10 * Time.deltaTime);
            joint.distance -= 10 * Time.deltaTime;
        }

        if(!fishing_rod.hook_on_rod && Input.GetKey(KeyCode.Mouse0) && !fish_on_hook)
        {
            transform.position = Vector2.MoveTowards(transform.position, rod_position.position, Time.deltaTime);
            joint.distance -= Time.deltaTime;
        }
        

        if(fish_on_hook)
        {
            fish = GetComponentInChildren<Fish>();
            if (fightStatus == "Green")
            {
                transform.position = Vector2.MoveTowards(transform.position, rod_position.position, 10 * Time.deltaTime);
                joint.distance -= 10 * Time.deltaTime;
            }
            else if (fightStatus == "Yellow")
            {
                transform.position = Vector2.MoveTowards(transform.position, rod_position.position, 5 * Time.deltaTime);
                joint.distance -= 5 * Time.deltaTime;
            }
            else if (fightStatus == "Red")
            {
                fish.is_caught = false;
                fish_on_hook = false;
                fightStatus = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            rb.mass = 0.5f;
            Joint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            transform.position = rod_position.position;
            rb.mass = 1;
            rb.gravityScale = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.freezeRotation = true;
            fishing_rod.hook_on_rod = true;
            fish.isFishOut = true;
            @object.transform.position = new Vector3(215, 331, 0);
            Destroy(joint);
            
        }
    }

    public void Joint()
    {
        joint = gameObject.AddComponent<DistanceJoint2D>();
        joint.connectedBody = rb_rod;
        float distance = Vector2.Distance(rod_position.position, gameObject.transform.position);
        joint.autoConfigureDistance = false;
        joint.distance = distance;
    }
}
