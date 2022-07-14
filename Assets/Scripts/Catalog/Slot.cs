using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Fish fish;

    private Text fishName;
    private Text fishValue;
    private Image fishSprite;

    private void Start()
    {
        fishSprite = transform.GetChild(0).GetComponent<Image>();
        fishName = transform.GetChild(1).GetComponent<Text>();
        fishValue = transform.GetChild(2).GetComponent<Text>();
    }

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
}
