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

    void Start()
    {
        tabSmall.onClick.AddListener(ShowTabSmall);
        tabMedium.onClick.AddListener(ShowTabMedium);
        tabLarge.onClick.AddListener(ShowTabLarge);
    }

    void HideAllTabs()
    {
        tabContentSmall.SetActive(false);
        tabContentMedium.SetActive(false);
        tabContentLarge.SetActive(false);
    }

    void ShowTabSmall()
    {
        HideAllTabs();
        tabContentSmall.SetActive(true);
    }
    void ShowTabMedium()
    {
        HideAllTabs();
        tabContentMedium.SetActive(true);
    }
    void ShowTabLarge()
    {
        HideAllTabs();
        tabContentLarge.SetActive(true);
    }
}
