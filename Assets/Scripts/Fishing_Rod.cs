using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fishing_Rod : MonoBehaviour
{
    public Rigidbody2D hook_rb;

    public Transform rod_point;
    public Transform hook_point;
    public Hook hook;
    LineRenderer lr;
    public int money;
    public bool hook_on_rod;
    public bool can_trow;
    float press_time_start;
    float max_power = 5;

    void Start()
    {
        hook_on_rod = true;
    }

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(hook_on_rod && !hook.fish_on_hook)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                press_time_start = Time.time;
                can_trow = true;
            }
            else if (Input.GetKeyUp(KeyCode.Mouse0) && can_trow)
            {
                if(hook.bait_size == 0)
                {
                    hook.bait_size = 1;
                }
                Trow_hook(Time.time - press_time_start);
                can_trow = false;
                hook_on_rod = false;
            }
        }
    }

    private void LateUpdate()
    {
        Draw_rope();
    }

    void Trow_hook(float power)
    {
        if(power > max_power)
        {
            power = max_power;
        }

        hook_rb.gravityScale = 1;
        hook_rb.AddForce(new Vector2(300, 100) * power);
    }

    void Draw_rope()
    {
        lr.SetPosition(0, rod_point.position);
        lr.SetPosition(1, hook_point.position);
    }
}
