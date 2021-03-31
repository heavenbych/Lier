using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private string _departure;
    private string _destination;
    private static LoadManager _instance;


    public string departure { get { return _departure; } set { _departure = value; } }
    public string destination { get { return _destination; } set { _destination = value; } }


    public static LoadManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(LoadManager)) as LoadManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (LoadManager._instance == null)
            LoadManager._instance = this;
        else if (_instance != this)
            Destroy(gameObject);
    }

    public void StartLoad(string departure, string destination)
    {
        this.departure = departure;
        this.destination = destination;
        print("From :" + this.departure);
        print("To :" + this.destination);
        SceneManager.LoadScene("Loading");
    }




}
