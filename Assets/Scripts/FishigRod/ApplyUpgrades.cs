using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpgrades : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private FishingRod fishingRod;

    [SerializeField] private List<Upgrades> upgrades;

    private void Awake()
    {
        foreach(Upgrades upgrade in upgrades)
        {
            if(upgrade is FishingLineLength fishingLineLength)
            {
                fishingRod.maxDistance += fishingLineLength.maxDistance * fishingLineLength.levelUpgrade;
            }
            else if(upgrade is BiggerBait biggerBait)
            {
                hook.bait.baitSizeStart += biggerBait.baitSize * biggerBait.levelUpgrade;
            }
        }
    }
}
