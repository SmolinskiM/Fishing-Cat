using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitSprite : MonoBehaviour
{
    private Hook hook;
    private SpriteRenderer bait;
    [SerializeField] private Sprite[] baitSprite;

    private void Start()
    {
        hook = GetComponentInParent<Hook>();
        bait = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(hook.baitSize == 0)
        {
            bait.sprite = null;
            return;
        }

        if(hook.baitSize < baitSprite.Length)
        {
            bait.sprite = baitSprite[hook.baitSize - 1];
            return;
        }
        
        bait.sprite = baitSprite[baitSprite.Length - 1];
    }
}
