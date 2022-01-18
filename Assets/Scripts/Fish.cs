using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public int fish_size;
    public int fish_id;
    public int value;
    GameObject hook_go;
    public Hook hook;
    Transform area;
    public bool isFishOut;

    bool reach_point = true;
    public bool is_caught;

    float position_x;
    float position_y;

    public int range;

    void Start()
    {
        hook_go = GameObject.FindGameObjectWithTag("Hook");
        hook = hook_go.GetComponent<Hook>();
        area = gameObject.transform.parent;
    }

    void Update()
    {
        Fish_movement();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook"))
        {
            if (hook.bait_size >= fish_size)
            {
                gameObject.transform.parent = hook_go.transform;
                is_caught = true;
                hook.fish_on_hook = true;
            }

            hook.bait_size = 0;
        }
    }

    void Fish_movement()
    {
        if (gameObject.transform.position == new Vector3(position_x, position_y, 0))
        {
            reach_point = true;
        }

        if (reach_point)
        {
            position_x = Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2);
            position_y = Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2);
            reach_point = false;
        }

        float dis = Vector2.Distance(gameObject.transform.position, hook.transform.position);

        if(dis <= range && hook.bait_size != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, hook_go.transform.position, 10 * Time.deltaTime);
        }
        else if(!is_caught)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(position_x, position_y, -20), 10 * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = hook_go.transform.position;
        }
    }
}
