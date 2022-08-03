using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private static Money instance;

    private int moneyHaving;
    
    public int MoneyHaving { get { return moneyHaving; } }
    public static Money Instance { get { return instance; } }


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddMoney(int moneyToAdd)
    {
        moneyHaving += moneyToAdd;
    }

    public bool SubtractMoney(int moneyToSubtract)
    {
        if(moneyHaving < moneyToSubtract)
        {
            return false;
        }
        moneyHaving -= moneyToSubtract;
        return true;
    }
}
