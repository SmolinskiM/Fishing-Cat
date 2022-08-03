using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogMeneger : MonoBehaviour
{    
    [SerializeField] private GameObject fishCatalog;

    public bool isEnableToOpen;

    private void Start()
    {
        fishCatalog.SetActive(false);
    }

    private void Update()
    {
        
        if(!FishingRod.Instance.isHookOnRod)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            isEnableToOpen = !isEnableToOpen;
            fishCatalog.SetActive(isEnableToOpen);
        }
    }
}
