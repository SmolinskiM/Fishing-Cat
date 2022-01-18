using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Fish : MonoBehaviour
{
    public GameObject[] fish;

    public int fish_max;
    public int fish_current;

    void Update()
    {
        fish_current = transform.childCount; 

        if(fish_current < fish_max)
        {
            float position_x = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            float position_y = Random.Range(gameObject.transform.position.y - gameObject.transform.localScale.y / 2, gameObject.transform.position.y + gameObject.transform.localScale.y / 2);
            int random_fish = Random.Range(0, fish.Length);
            GameObject new_fish = Instantiate(fish[random_fish], new Vector3(position_x,position_y, -20), Quaternion.identity);
            new_fish.transform.parent = gameObject.transform;
        }
    }
}
