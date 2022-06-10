using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Fish")]
public class Fish : ScriptableObject
{
    public bool isDiscovered;
    public int fishSize;
    public int value;

    public Vector3 ofset;
    public Sprite fishSprite;
}
