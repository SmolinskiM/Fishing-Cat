using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogMeneger : MonoBehaviour
{ 
    [SerializeField] private Canvas fishCatalog;
    private bool isEnableToOpen;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            isEnableToOpen = true;
        }
        else
        {
            isEnableToOpen = false;
        }
        fishCatalog.gameObject.SetActive(isEnableToOpen);
    }
}
