using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingBasket : MonoBehaviour
{
    public MarsRock.RockType ExpectedType;
    public Text BasketName;
    public SortingBasketMonitor SortingMonitor;

    public void Start()
    {
        BasketName.text = ExpectedType.ToString();
    }

    public void CheckRock(GameObject rock)
    {
        MarsRock.RockType type = rock.GetComponent<MarsRock>().Type;
        if(type != ExpectedType)
        {
            Debug.Log("Wrong!");
            SortingMonitor.Incorrect(rock);
        }
        else
        {
            Debug.Log("Correct!");
            SortingMonitor.Correct(rock);
        }
    }
}
