using UnityEngine;
using UnityEngine.UI;

public class ShopOpen : MonoBehaviour
{
    public bool isShopOpen;

    [SerializeField] private Text shopText;
    [SerializeField] private GameObject shop;

    private void Update()
    {
        OpenShop();
    }

    private void OpenShop()
    {
        if (FishingRod.Instance.isHookOnRod)
        {
            if (Input.GetKeyDown("p"))
            {
                isShopOpen = !isShopOpen;
                shop.SetActive(isShopOpen);
            }
            shopText.gameObject.SetActive(!isShopOpen);
        }
        else
        {
            isShopOpen = false;
            shop.SetActive(isShopOpen);
            shopText.gameObject.SetActive(isShopOpen);
        }
    }
}
