using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRock : MonoBehaviour
{
    public RockType Type;
    public float Weight;

    public void Start()
    {
        Weight = 2;
    }

    public enum RockType
    {
        Olivine,
        Basalt,
        Geothite,
        Gypsum
    }

    public void RandomizeType()
    {
        Type = GetRandomEnum<RockType>();
        Debug.Log(Type);
    }
    static T GetRandomEnum<T>()
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(Random.Range(0, A.Length));
        return V;
    }
}
