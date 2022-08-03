using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{   
    [SerializeField] private Text moneyText;

    [SerializeField] private FishingRod fishingRod;
    [SerializeField] private Hook hook;

    [SerializeField] private FishingLineLength fishingLineLength;

    [SerializeField] private Button biggerBaitButton;
    [SerializeField] private Button fishingLineLengthButton;

    [SerializeField] private BiggerBait biggerBait;


    private void Start()
    {
        biggerBaitButton.onClick.AddListener(BiggerBait);
        fishingLineLengthButton.onClick.AddListener(FishingLineLengthUpgrade);
    }

    private void FishingLineLengthUpgrade()
    {
        if(fishingLineLength.levelUpgrade == fishingLineLength.levelUpgradeMax)
        {
            return;
        }

        if(Money.Instance.SubtractMoney(fishingLineLength.price))
        {
            moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
            fishingRod.maxDistance += fishingLineLength.maxDistance;
            fishingLineLength.levelUpgrade++;
        }
    }

    private void BiggerBait()
    {
        if (biggerBait.levelUpgrade == biggerBait.levelUpgradeMax)
        {
            return;
        }

        if(Money.Instance.SubtractMoney(biggerBait.price))
        {
            moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
            hook.bait.baitSizeStart += biggerBait.baitSize;
            hook.bait.baitSize += biggerBait.baitSize;
            biggerBait.levelUpgrade++;
        }
    }
}
