using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogMeneger : MonoBehaviour
{
    [SerializeField] private FishingRod fishingRod;
    
    [SerializeField] private Canvas fishCatalog;

    public bool isEnableToOpen;

    private void Start()
    {
        fishCatalog.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!fishingRod.isHookOnRod)
        {
            return;
        }

        if(!Input.GetKeyDown(KeyCode.Tab))
        {
            return;
        }
        isEnableToOpen = !isEnableToOpen;
        fishCatalog.gameObject.SetActive(isEnableToOpen);
    }
}
