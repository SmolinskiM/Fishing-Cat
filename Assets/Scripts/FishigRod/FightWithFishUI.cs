using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWithFishUI : MonoBehaviour
{
    private RectTransform fishUI;
    [SerializeField] private FightWithFish fightWithFish;
    [SerializeField] private Transform fishingWheel;

    private void Start()
    {
        fishUI = GetComponent<RectTransform>();
    }

    private void Update()
    {
        fishingWheel.transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal") * 10));
        fishUI.localPosition = new Vector3(fightWithFish.FishPosition * 2, 0, 0);
    }

}
