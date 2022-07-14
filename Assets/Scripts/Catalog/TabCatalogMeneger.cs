using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabCatalogMeneger : MonoBehaviour
{
    [SerializeField] private Button tabSmall;
    [SerializeField] private Button tabMedium;
    [SerializeField] private Button tabLarge;

    [SerializeField] private GameObject tabContentSmall;
    [SerializeField] private GameObject tabContentMedium;
    [SerializeField] private GameObject tabContentLarge;

    private void Start()
    {
        tabSmall.onClick.AddListener(ShowTabSmall);
        tabMedium.onClick.AddListener(ShowTabMedium);
        tabLarge.onClick.AddListener(ShowTabLarge);
    }

    private void HideAllTabs()
    {
        tabContentSmall.SetActive(false);
        tabContentMedium.SetActive(false);
        tabContentLarge.SetActive(false);
    }

    private void ShowTabSmall()
    {
        HideAllTabs();
        tabContentSmall.SetActive(true);
    }
    private void ShowTabMedium()
    {
        HideAllTabs();
        tabContentMedium.SetActive(true);
    }
    private void ShowTabLarge()
    {
        HideAllTabs();
        tabContentLarge.SetActive(true);
    }
}
