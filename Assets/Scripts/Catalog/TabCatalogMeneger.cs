using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabCatalogMeneger : MonoBehaviour
{
    [SerializeField] private Button tabSmall;
    [SerializeField] private Button tabMedium;
    [SerializeField] private Button tabLarge;

    [SerializeField] private GameObject content;

    public Slot[] slots;

    enum SizeContent
    {
        Small = 1,
        Medium,
        Large
    }

    private void Start()
    {
        slots = content.GetComponentsInChildren<Slot>();
        tabSmall.onClick.AddListener(ClickTabSmal);
        tabMedium.onClick.AddListener(ClickTabMedium);
        tabLarge.onClick.AddListener(ClickTabLarge);
        HideContent();
        ClickTabSmal();
    }

    private void ClickTabSmal()
    {
        HideContent();
        ChangeContent((int)SizeContent.Small);
    }

    private void ClickTabMedium()
    {
        HideContent();
        ChangeContent((int)SizeContent.Medium);
    }

    private void ClickTabLarge()
    {
        HideContent();
        ChangeContent((int)SizeContent.Large);
    }

    private void ChangeContent(int sizeContent)
    {
        foreach(Slot slot in slots)
        {
            if((int)slot.fish.fishSize == sizeContent)
            {
                slot.gameObject.SetActive(true);
            }
        }
    }

    private void HideContent()
    {
        foreach(Slot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }
    }
}
