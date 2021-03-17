using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsRock : MonoBehaviour
{
    public RockType Type;

    public enum RockType
    {
        Olivine,
        Basalt,
        Geothite,
        Gypsum
    }
}
