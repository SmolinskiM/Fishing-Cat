using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatCatalogSlot : MonoBehaviour
{
    private Fish[] fishesSmall;
    private Fish[] fishesMedium;
    private Fish[] fishesLarge;

    private Text fishName;
    private Text fishValue;
    private Image fishSprite;

    [SerializeField] private GameObject slotPref;
    [SerializeField] private GameObject tabContentSmall;
    [SerializeField] private GameObject tabContentMedium;
    [SerializeField] private GameObject tabContentLarge;

    void Start()
    {
        fishesSmall = Resources.LoadAll<Fish>("Fishes/Small");
        fishesMedium = Resources.LoadAll<Fish>("Fishes/Medium");
        fishesLarge = Resources.LoadAll<Fish>("Fishes/Large");

        fishSprite = slotPref.transform.GetChild(0).GetComponent<Image>();
        fishName = slotPref.transform.GetChild(1).GetComponent<Text>();
        fishValue = slotPref.transform.GetChild(2).GetComponent<Text>();

        foreach (Fish fish in fishesSmall)
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

            GameObject slotNew = Instantiate(slotPref, tabContentSmall.transform.position, Quaternion.identity);
            slotNew.GetComponent<Slot>().fish = fish;
            slotNew.transform.parent = tabContentSmall.transform;
        }

        foreach (Fish fish in fishesMedium)
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

            GameObject slotNew = Instantiate(slotPref, tabContentMedium.transform.position, Quaternion.identity);
            slotNew.GetComponent<Slot>().fish = fish;
            slotNew.transform.parent = tabContentMedium.transform;
        }

        foreach (Fish fish in fishesLarge)
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

            GameObject slotNew = Instantiate(slotPref, tabContentLarge.transform.position, Quaternion.identity);
            slotNew.GetComponent<Slot>().fish = fish;
            slotNew.transform.parent = tabContentLarge.transform;
        }
    }
}
