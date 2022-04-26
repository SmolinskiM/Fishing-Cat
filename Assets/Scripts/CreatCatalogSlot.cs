using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatCatalogSlot : MonoBehaviour
{
    [SerializeField] private Fish[] fishes;

    private Text fishName;
    private Text fishValue;
    private Image fishSprite;

    [SerializeField] private GameObject slotPref;
    [SerializeField] private GameObject content;

    void Awake()
    {
        fishes = Resources.LoadAll<Fish>("Fish");

        fishSprite = slotPref.transform.GetChild(0).GetComponent<Image>();
        fishName = slotPref.transform.GetChild(1).GetComponent<Text>();
        fishValue = slotPref.transform.GetChild(2).GetComponent<Text>();

        foreach (Fish fish in fishes)
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
            GameObject slotNew = Instantiate(slotPref, content.transform.position, Quaternion.identity);
            slotNew.GetComponent<Slot>().fish = fish;
            slotNew.transform.parent = content.transform;
        }
    }
}
