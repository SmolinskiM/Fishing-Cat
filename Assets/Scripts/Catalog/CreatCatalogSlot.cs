using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatCatalogSlot : MonoBehaviour
{
    private FishData[] fishes;
    [SerializeField] private Slot slotPref;
    [SerializeField] private Transform content;

    private void Awake()
    {
        fishes = Resources.LoadAll<FishData>("Fishes");

        foreach (FishData fish in fishes)
        {
            Slot slotNew = Instantiate(slotPref, content.position, Quaternion.identity, content);
            slotNew.fish = fish;
            slotNew.SetUpSlot(fish);
        }
    }
}
