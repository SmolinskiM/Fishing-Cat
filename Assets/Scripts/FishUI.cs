using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUI : MonoBehaviour
{
    [SerializeField] private Hook hook;

    private FishMovment fishMovment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Red"))
        {
            fishMovment = hook.GetComponentInChildren<FishMovment>();
            hook.isFishOnHook = false;
            fishMovment.isFishOnHook = false;
            fishMovment.transform.eulerAngles = Vector3.zero;
            fishMovment.transform.parent = fishMovment.area;
        }
    }
}
