using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDescriptionChecker : MonoBehaviour
{
    [SerializeField] private Image descriptionBg;
    private DisplayDescription[] displayDescriptions;

    private void Start()
    {
        displayDescriptions = GetComponentsInChildren<DisplayDescription>();
    }

    private void Update()
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
