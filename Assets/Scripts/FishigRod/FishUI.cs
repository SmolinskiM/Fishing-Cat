using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUI : MonoBehaviour
{
    [SerializeField] private Hook hook;

    private FishMovment fishMovment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Break"))
        {
            fishMovment = hook.GetComponentInChildren<FishMovment>();
            hook.isFishOnHook = false;
            fishMovment.isFishOnHook = false;
            fishMovment.transform.eulerAngles = Vector3.zero;
            fishMovment.transform.parent = fishMovment.area;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("RollingFast"))
        {
            hook.RollingUp(15);
        }

        if (collision.CompareTag("RollingNormal"))
        {
            hook.RollingUp(10);
        }
    }
}
