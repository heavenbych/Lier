using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MapManager.Instance.mapStatus = MapStatus.Village;
        LoadManager.Instance.StartLoad("Char", "Village");
    }

    
}
