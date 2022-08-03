using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayDescription: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isMouseOn;
    
    [SerializeField] private Text descriptionText;
    [SerializeField] private Image descriptionBg;
    [SerializeField] private Upgrades upgrades;
    
    private Vector3 ofset;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = descriptionBg.GetComponent<RectTransform>();
        ofset = new Vector3(descriptionBg.GetComponent<RectTransform>().rect.width, 0, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOn = false;
    }

    private void Update()
    {
        if(!isMouseOn)
        {
            return;
        }
        TextOnMouse();
    }

    private void TextOnMouse()
    {
        ofset = new Vector3(rectTransform.rect.width /2 + 10, 0, 0);
        descriptionText.text = upgrades.description;
        descriptionBg.transform.position = Input.mousePosition + ofset;
    }
}
