using UnityEngine;

public class FightWithFish : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private Canvas fightCanvas;
    [SerializeField] private GameObject fishingWhell;
    [SerializeField] private Transform fishUI;
    [SerializeField] private Transform[] target;
    [SerializeField] private RectTransform fishDeafultPoint;


    private int selectTarget;
    private float cooldown;
    private float moveSpeed;
    private RectTransform fishRT;

    private void Start()
    {
        fishRT = fishUI.gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        ActiveCanvas();
    }

    void ActiveCanvas()
    {
        if (hook.isFishOnHook && !hook.fishingRod.isHookOnRod)
        {
            fightCanvas.gameObject.SetActive(true);
            StartMovingFishUI();
        }
        else
        {
            fishRT.position = fishDeafultPoint.position;
            fightCanvas.gameObject.SetActive(false);
        }
    }

    void StartMovingFishUI()
    {
        fishingWhell.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 10);

        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 2;
            selectTarget = Random.Range(0, 2);
            moveSpeed = Random.Range(1.0f, hook.GetComponentInChildren<FishMovment>().fish.fishSize);
        }

        fishRT.position = Vector2.MoveTowards(fishUI.transform.position, target[selectTarget].position, 75 * moveSpeed * Time.deltaTime);
        
        fishUI.transform.Translate(Input.GetAxis("Horizontal") * 200 * Time.deltaTime, 0, 0);
    }
}
