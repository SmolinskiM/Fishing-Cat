using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    [SerializeField] private FishingRod fishingRod;

    [SerializeField] private FishingLineLength fishingLineLength;

    void Start()
    {
        fishingRod.maxDistance += fishingLineLength.maxDistance * fishingLineLength.levelUpgrade;
    }
}
