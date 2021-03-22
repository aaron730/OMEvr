using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortingBasket : MonoBehaviour
{
    public MarsRock.RockType ExpectedType;
    public Text BasketName;

    public void Start()
    {
        BasketName.text = ExpectedType.ToString();
    }

    public void CheckRock(MarsRock.RockType type)
    {
        if(type != ExpectedType)
        {
            Debug.Log("Wrong!");
        }
        else
        {
            Debug.Log("Correct!");
        }
    }
}
