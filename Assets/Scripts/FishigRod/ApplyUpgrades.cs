using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private FishingRod fishingRod;

    [SerializeField] private FishingLineLength fishingLineLength;
    [SerializeField] private BiggerBait biggerBait;

    void Start()
    {
        fishingRod.maxDistance += fishingLineLength.maxDistance * fishingLineLength.levelUpgrade;
        hook.baitSizeStart += biggerBait.baitSize * biggerBait.levelUpgrade;
    }
}
