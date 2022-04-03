using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    public bool isShopOpen;

    [SerializeField] private FishingRod fishingRod;
    [SerializeField] private Text shopText;
    [SerializeField] private Canvas shop;

    private void Update()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        if (fishingRod.isHookOnRod)
        {
            if (Input.GetKeyDown("p"))
            {
                isShopOpen = !isShopOpen;
                shop.gameObject.SetActive(isShopOpen);
            }
            shopText.gameObject.SetActive(!isShopOpen);
        }
        else
        {
            isShopOpen = false;
            shop.gameObject.SetActive(isShopOpen);
            shopText.gameObject.SetActive(isShopOpen);
        }
    }
}
