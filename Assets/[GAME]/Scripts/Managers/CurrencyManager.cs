using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager main;

    public int Currency;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        Currency = 3;
    }

    public void IncreaseCurrency(int increaseAmount)
    {
        Currency += increaseAmount;
    }

    public bool DecreaseCurrency(int decreaseAmount)
    {
        if(decreaseAmount <= Currency)
        {
            //Buy item
            Currency -= decreaseAmount;
            return true;
        }
        else
        {
            Debug.Log("Dont have enough money");
            return false;
        }
    }
}
