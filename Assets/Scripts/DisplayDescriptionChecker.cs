using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescriptionChecker : MonoBehaviour
{
    private DisplayDescription[] displayDescriptions;
    [SerializeField] private Image descriptionBg;

    void Start()
    {
        displayDescriptions = GetComponentsInChildren<DisplayDescription>();
    }

    void Update()
    {
        foreach(DisplayDescription displayDescription in displayDescriptions)
        {
            if(displayDescription.isMouseOn)
            {
                descriptionBg.gameObject.SetActive(true);
                return;
            }
        }
        descriptionBg.gameObject.SetActive(false);
    }
}
