using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{   
    [SerializeField] private Text moneyText;

    [SerializeField] private FishingRod fishingRod;
    [SerializeField] private Hook hook;

    [SerializeField] private FishingLineLength fishingLineLength;

    [SerializeField] private Button fishingLineLengthButton;

    [SerializeField] private BiggerBait biggerBait;

    [SerializeField] private Button biggerBaitButton;

    private void Start()
    {
        biggerBaitButton.onClick.AddListener(BiggerBait);
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

    private void BiggerBait()
    {
        if (fishingRod.money < biggerBait.price)
        {
            return;
        }

        if (biggerBait.levelUpgrade == biggerBait.levelUpgradeMax)
        {
            return;
        }

        fishingRod.money -= biggerBait.price;
        moneyText.text = fishingRod.money.ToString() + "$";
        hook.baitSizeStart += biggerBait.baitSize;
        hook.baitSize += biggerBait.baitSize;
        biggerBait.levelUpgrade++;
    }
}
