using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public FishData fish;
    
    [SerializeField] private Text fishName;
    [SerializeField] private Text fishValue;
    [SerializeField] private Image fishSprite;

    private void Update()
    {
        if(fish.isDiscovered)
        {
            fishName.text = fish.name;
            fishValue.text = fish.value.ToString() + "$";
            fishSprite.sprite = fish.fishSprite;
            fishSprite.color = Color.white;
            Destroy(GetComponent<Slot>());
        }
    }

    public void SetUpSlot(FishData fish)
    {
        fishName.text = fish.name;
        fishValue.text = fish.value.ToString() + "$";
        fishSprite.sprite = fish.fishSprite;
        fishSprite.color = Color.white;
        if (!fish.isDiscovered)
        {
            fishSprite.color = Color.black;
            fishName.text = "???";
            fishValue.text = "???";
        }
    }
}
