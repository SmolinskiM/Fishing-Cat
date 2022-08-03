using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private int fishCurrent;
    
    [SerializeField] private int fishMax;

    [SerializeField] private FishData[] fish;
    [SerializeField] private Fish fishPrefab;

    private void Update()
    {
        fishCurrent = transform.childCount;

        if(fishCurrent < fishMax)
        {
            float positionX = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            float positionY = Random.Range(gameObject.transform.position.y - gameObject.transform.localScale.y / 2, gameObject.transform.position.y + gameObject.transform.localScale.y / 2);
            int fishRandom = Random.Range(0, fish.Length);
            Fish fishNew = Instantiate(fishPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
            fishNew.FishSetup(fish[fishRandom], transform);
        }
    }
}
