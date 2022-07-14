using UnityEngine;
using UnityEngine.UI;

public class CatchingFish: MonoBehaviour
{   
    private FishMovement fish;
    private FishingRod fishingRod;

    [SerializeField] private Canvas whatToDoWithFish;
    [SerializeField] private Text moneyText;

    [SerializeField] private Button makeBait;
    [SerializeField] private Button sellFish;

    private void Start()
    {
        makeBait.onClick.AddListener(MakeBait);
        sellFish.onClick.AddListener(SellFish);
        fishingRod = GetComponent<FishingRod>();
        moneyText.text = fishingRod.money.ToString() + "$";
    }

    private void Update()
    {
        moneyText.gameObject.SetActive(fishingRod.isHookOnRod);

        if(fishingRod.isHookOnRod && fishingRod.hook.isFishOnHook)
        {
            whatToDoWithFish.gameObject.SetActive(true);
        }
        else
        {
            whatToDoWithFish.gameObject.SetActive(false);
        }
    }

    public void SellFish()
    {
        fish = fishingRod.hook.gameObject.GetComponentInChildren<FishMovement>();
        fishingRod.money += fish.fish.value;
        moneyText.text = fishingRod.money.ToString() + "$";
        fishingRod.hook.isFishOnHook = false;
        fish.fish.isDiscovered = true;
        Destroy(fish.gameObject);
    }

    public void MakeBait()
    {
        fish = fishingRod.hook.gameObject.GetComponentInChildren<FishMovement>();
        fishingRod.hook.baitSize = fish.fish.fishSize + 1;
        fishingRod.hook.isFishOnHook = false;
        fish.fish.isDiscovered = true;
        Destroy(fish.gameObject);
    }
}
