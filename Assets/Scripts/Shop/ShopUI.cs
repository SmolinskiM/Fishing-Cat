using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Text upgradePrice;
    [SerializeField] private Upgrades upgrades;

    [SerializeField] private Image[] levelCout;

    private void Start()
    {
        upgradePrice.text = upgrades.price.ToString() + "$";
    }

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
