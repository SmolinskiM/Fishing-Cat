using UnityEngine;

public class FightWithFish : MonoBehaviour
{
    
    public float moveSpeed;
    public float fastArea;
    public float breakArea;
    
    [SerializeField] private Hook hook;
    [SerializeField] private GameObject figthCanvas;
    
    private Fish fish;
    private int direction;
    private readonly float moveSpeedFishUI = 50;
    private float fishPosition = 0;
    private float cooldown = 2;
    
    public float FishPosition { get { return fishPosition; } }

    private void Update()
    {
        if (hook.isFishOnHook && !hook.fishingRod.isHookOnRod)
        {
            fish = hook.GetComponentInChildren<Fish>();
            Fight();
            figthCanvas.SetActive(true);
        }
        else
        {
            fishPosition = 0;
            figthCanvas.SetActive(false);
        }
    }

    private void Fight()
    {
        if(Mathf.Abs(FishPosition) <= fastArea)
        {
            hook.RollingUp(moveSpeed * 1.5f);
        }
        else
        {
            hook.RollingUp(moveSpeed);
        }

        if(Mathf.Abs(FishPosition) >= breakArea)
        {
            FishMovement fishMovment;

            fishMovment = hook.GetComponentInChildren<FishMovement>();
            hook.isFishOnHook = false;
            fishMovment.isFishOnHook = false;
            fishMovment.transform.eulerAngles = Vector3.zero;
            fishMovment.transform.parent = fishMovment.area;
        }

        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 2;
            direction = Random.Range(0, 2) * 2 - 1;
        }

        fishPosition += (moveSpeedFishUI * (int)fish.FishCurrent.fishSize * direction) * Time.deltaTime;
        fishPosition += Input.GetAxis("Horizontal") * 200 * Time.deltaTime;
    }
}
