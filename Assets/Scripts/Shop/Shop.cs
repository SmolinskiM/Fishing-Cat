using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{   
    [SerializeField] private Text moneyText;

    [SerializeField] private FishingRod fishingRod;

    [SerializeField] private FishingLineLength fishingLineLength;

    [SerializeField] private Button fishingLineLengthButton;

    void Start()
    {
        fishingLineLengthButton.onClick.AddListener(FishingLineLengthUpgrade);
    }

    private void FishingLineLengthUpgrade()
    {
        if(fishingRod.money < fishingLineLength.price)
        {
            return;
        }

        if(fishingLineLength.levelUpgrade == fishingLineLength.levelUpgradeMax)
        {
            return;
        }

        fishingRod.money -= fishingLineLength.price;
        moneyText.text = fishingRod.money.ToString() + "$";
        fishingRod.maxDistance += fishingLineLength.maxDistance;
        fishingLineLength.levelUpgrade++;
    }
}
