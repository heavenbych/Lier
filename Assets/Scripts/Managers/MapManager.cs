using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manager about Map Status
/// Ex) Village, Dungeon...
/// </summary>
public enum MapStatus { None, Village, Dungeon };
public class MapManager : MonoBehaviour
{
    private static MapManager _instance;

    [SerializeField] private MapStatus _mapStatus;
    public MapStatus mapStatus { get { return _mapStatus; } set { _mapStatus = value; } }



    public static MapManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(MapManager)) as MapManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (MapManager._instance == null)
            MapManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        mapStatus = MapStatus.None;
    }
}
