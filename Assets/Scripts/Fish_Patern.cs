using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish_Patern : MonoBehaviour
{
    Transform start_area;
    Fish fish;
    public GameObject @object;

    void Start()
    {
        start_area = transform.parent;
        fish = GetComponent<Fish>();
    }

    void Update()
    {
        if(fish.is_caught && !fish.isFishOut)
        {
            Start_fishing();
        }
        else if(!fish.is_caught)
        {
            transform.parent = start_area;
            @object = fish.hook.@object;
        }
    }

    void Start_fishing()
    {
        @object.transform.position = new Vector3(45, 331, 0);
        if ((int)Time.time % 5 == 0)
        {
            if(@object.transform.position.x > 50)
            {
                @object.transform.position = new Vector3(45, 331, 0);
            }
            else
            {
                @object.transform.position = new Vector3(400, 331, 0);
            }
        }
    }
}
