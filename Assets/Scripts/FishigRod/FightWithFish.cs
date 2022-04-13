using UnityEngine;

public class FightWithFish : MonoBehaviour
{
    [SerializeField] private Hook hook;
    [SerializeField] private Canvas fightCanvas;
    [SerializeField] private GameObject fishingWhell;
    [SerializeField] private Transform fishUI;
    [SerializeField] private Transform targetL;
    [SerializeField] private Transform targetR;
    [SerializeField] private RectTransform fishDeafultPoint;


    private int selectTarget;
    private float cooldown;
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
            StartMovingFish();
        }
        else
        {
            fishRT.position = fishDeafultPoint.position;
            fightCanvas.gameObject.SetActive(false);
        }
    }

    void StartMovingFish()
    {
        fishingWhell.transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * 10);

        if (Time.time >= cooldown)
        {
            cooldown = Time.time + 2;
            selectTarget = Random.Range(0, 2);
        }

        if (selectTarget == 0)
        {
            fishRT.position = Vector2.MoveTowards(fishUI.transform.position, targetL.position, 100 * Time.deltaTime);
        }
        else
        {
            fishRT.position = Vector2.MoveTowards(fishUI.transform.position, targetR.position, 100 * Time.deltaTime);
        }

        fishUI.transform.Translate(Input.GetAxis("Horizontal") * 150 * Time.deltaTime, 0, 0);
    }
}
