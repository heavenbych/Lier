using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaceCanvas : MonoBehaviour
{
    public void moveToD()
    {
        MapManager.Instance.mapStatus = MapStatus.Dungeon;
        LoadManager.Instance.StartLoad("Village", "Dungeon");
    }
}
