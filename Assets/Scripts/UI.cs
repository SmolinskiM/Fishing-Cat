using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //90% do zmiany
    public Text money_text;
    public Canvas fish_menegment;
    public Hook hook;
    public Fish fish;
    Fishing_Rod fishing_rod;

    public Image image;
    public Image fishUI;
    public Canvas canvas;

    void Start()
    {
        fishing_rod = GetComponent<Fishing_Rod>();
    }

    private void Update()
    {
        if(hook.fish_on_hook && fishing_rod.hook_on_rod)
        {
            fish_menegment.gameObject.SetActive(true);
        }
        else
        {
            fish_menegment.gameObject.SetActive(false);
        }

        if(hook.fish_on_hook)
        {
            fish = hook.gameObject.GetComponentInChildren<Fish>();
            canvas.gameObject.SetActive(true);

        }

        if(hook.fish_on_hook)
        {
            float fishMove = Input.GetAxisRaw("Horizontal");
            image.rectTransform.Rotate(0, 0, -fishMove * 20);
            fishUI.transform.Translate(fishMove, 0, 0);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
        
    }

    public void Sell_fish()
    {
        fishing_rod.money += fish.value;
        money_text.text = fishing_rod.money.ToString() + "$";
        hook.fish_on_hook = false;
        hook.fightStatus = null;
        Destroy(fish.gameObject);
    }

    public void Bait_fish()
    {
        hook.bait_size = fish.fish_size + 1;
        hook.fish_on_hook = false;
        hook.fightStatus = null;
        Destroy(fish.gameObject);
    }
}
