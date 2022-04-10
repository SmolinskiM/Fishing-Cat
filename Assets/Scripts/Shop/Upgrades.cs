using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : ScriptableObject
{
    public string description;
    
    public int price;
    public int levelUpgrade;
    public int levelUpgradeMax;
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/FishingLineLength")]
public class FishingLineLength : Upgrades
{
    public int maxDistance;
}

[CreateAssetMenu(fileName = "Upgrades", menuName = "Upgrades/BiggerBait")]
public class BiggerBait : Upgrades
{
    public int baitSize;
}
