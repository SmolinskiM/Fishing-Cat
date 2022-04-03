using UnityEngine;
using UnityEngine.UI;

public class FishingRodUI : MonoBehaviour
{
    [SerializeField] private GameObject powerBarCanvas;

    [SerializeField] private Slider powerBar;

    [SerializeField] private FishingRod fishingRod;

    void Update()
    {
        if(!fishingRod.isThrowable)
        {
            powerBarCanvas.SetActive(false);
        }
        else
        {
            powerBarCanvas.SetActive(true);
        }

        powerBar.value = (Time.time - fishingRod.pressTimeStart) / fishingRod.maxPower;

    }
}
