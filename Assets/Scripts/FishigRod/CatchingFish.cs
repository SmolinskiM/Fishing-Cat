using UnityEngine;
using UnityEngine.UI;

public class CatchingFish: MonoBehaviour
{   
    private Fish fish;
    private FishingRod fishingRod;

    [SerializeField] private GameObject whatToDoWithFish;
    [SerializeField] private Text moneyText;

    [SerializeField] private Button makeBait;
    [SerializeField] private Button sellFish;

    private void Start()
    {
        makeBait.onClick.AddListener(MakeBait);
        sellFish.onClick.AddListener(SellFish);
        fishingRod = GetComponent<FishingRod>();
        moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
    }

    private void Update()
    {
        moneyText.gameObject.SetActive(fishingRod.isHookOnRod);

        if(fishingRod.isHookOnRod && fishingRod.hook.isFishOnHook)
        {
            whatToDoWithFish.SetActive(true);
        }
        else
        {
            whatToDoWithFish.SetActive(false);
        }
    }

    public void SellFish()
    {
        fish = fishingRod.hook.gameObject.GetComponentInChildren<Fish>();
        Money.Instance.AddMoney(fish.FishCurrent.value);
        moneyText.text = Money.Instance.MoneyHaving.ToString() + "$";
        fishingRod.hook.isFishOnHook = false;
        fish.FishCurrent.isDiscovered = true;
        Destroy(fish.gameObject);
    }

    public void MakeBait()
    {
        fish = fishingRod.hook.gameObject.GetComponentInChildren<Fish>();
        fishingRod.hook.bait.baitSize = (int)fish.FishCurrent.fishSize + 1;
        fishingRod.hook.isFishOnHook = false;
        fish.FishCurrent.isDiscovered = true;
        Destroy(fish.gameObject);
    }
}
