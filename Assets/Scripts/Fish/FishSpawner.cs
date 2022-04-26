using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    private int fishCurrent;
    
    private FishMovment fishMovment;
    
    [SerializeField] private int fishMax;
    
    [SerializeField] private Fish[] fish;
    [SerializeField] private GameObject fishPrefab;

    void Update()
    {
        fishCurrent = transform.childCount;

        if(fishCurrent < fishMax)
        {
            float positionX = Random.Range(gameObject.transform.position.x - gameObject.transform.localScale.x / 2, gameObject.transform.position.x + gameObject.transform.localScale.x / 2);
            float positionY = Random.Range(gameObject.transform.position.y - gameObject.transform.localScale.y / 2, gameObject.transform.position.y + gameObject.transform.localScale.y / 2);
            int fishRandom = Random.Range(0, fish.Length);
            GameObject fishNew = Instantiate(fishPrefab, new Vector3(positionX, positionY, 0), Quaternion.identity);
            FishSetup(fishNew, fishRandom);
        }
    }

    void FishSetup(GameObject fishNew, int fishRandom)
    {
        fishNew.transform.parent = gameObject.transform;
        fishMovment = fishNew.GetComponent<FishMovment>();
        fishMovment.fishId = fish[fishRandom].fishId;
        fishMovment.fishId = fish[fishRandom].fishId;
        fishMovment.fishSize = fish[fishRandom].fishSize;
        fishMovment.value = fish[fishRandom].value;
        fishMovment.range = fish[fishRandom].range;
        fishMovment.fish = fish[fishRandom];

        fishNew.GetComponent<SpriteRenderer>().sprite = fish[fishRandom].fishSprite;
    }
}
