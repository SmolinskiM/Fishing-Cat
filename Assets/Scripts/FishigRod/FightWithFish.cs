using UnityEngine;

public class FightWithFish : MonoBehaviour
{ 
    public float FishPosition { get; private set; } = 0;
    
    public float moveSpeed;
    public float fastArea;
    public float breakArea;
    
    [SerializeField] private Hook hook;
    [SerializeField] private Canvas figthCnvas;
    private FishMovement fishMovement;
    private int direction;
    private float moveSpeedFishUI;
    private float cooldown;

    private void Start()
    {
        cooldown = 2;
        moveSpeedFishUI = 50;
    }

    private void Update()
    {
        if (hook.isFishOnHook && !hook.fishingRod.isHookOnRod)
        {
            fishMovement = hook.GetComponentInChildren<FishMovement>();
            Fight();
            figthCnvas.gameObject.SetActive(true);
        }
        else
        {
            FishPosition = 0;
            figthCnvas.gameObject.SetActive(false);
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

        FishPosition += (moveSpeedFishUI * fishMovement.fish.fishSize * direction) * Time.deltaTime;
        FishPosition += Input.GetAxis("Horizontal") * 200 * Time.deltaTime;
    }
}
