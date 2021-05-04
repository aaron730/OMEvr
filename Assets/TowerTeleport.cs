using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTeleport : MonoBehaviour
{
    public GameObject Player;

    public Transform TopFloor;
    public Transform BottomFloor;

    public void TeleportUp()
    {
        Player.transform.position = TopFloor.position;
    }

    public void TeleportDown()
    {
        Player.transform.position = BottomFloor.position;
    }
}
