using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Upgrades upgrades;

    [SerializeField] private Image[] levelCout;

    void Update()
    {
        if(upgrades.levelUpgrade == 0)
        {
            return;
        }

        for(int i = 0; i < upgrades.levelUpgrade; i++)
        {
            levelCout[i].color = Color.black;
        }
    }
}
