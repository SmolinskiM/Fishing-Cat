using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Fish")]
public class FishData : ScriptableObject
{
    public bool isDiscovered;
    public int value;

    public FishSize fishSize;
    public Vector3 ofset;
    public Sprite fishSprite;

    public enum FishSize
    {
        Small = 1,
        Medium,
        Large
    }
}
