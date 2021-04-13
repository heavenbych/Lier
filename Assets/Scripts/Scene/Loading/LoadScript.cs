using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    public Slider slider;
    bool IsDone = false;
    float fTime = 0f;
    
    AsyncOperation async_operation;

    private void Awake()
    {
        System.GC.Collect();
        UIManager.Instance.DisableAllUI();
    }
    private void Start()
    {
        StartCoroutine(StartLoad(LoadManager.Instance.destination));
    }

    private void Update()
    {
        fTime += Time.deltaTime;
        slider.value = fTime;

        if (fTime >= 1)
            async_operation.allowSceneActivation = true;
    }

    private void OnDestroy()
    {
        if (MapManager.Instance.mapStatus.Equals(MapStatus.Dungeon))
            UIManager.Instance.CombatOn();
        else if (MapManager.Instance.mapStatus.Equals(MapStatus.Village))
            UIManager.Instance.PeaceOn();
    }
    public IEnumerator StartLoad(string strSceneName)
    {
        async_operation = SceneManager.LoadSceneAsync(strSceneName);
        async_operation.allowSceneActivation = false;

        if (IsDone == false)
        {
            IsDone = true;

            while (async_operation.progress < 0.9f)
            {
                slider.value = async_operation.progress;

                yield return null;

            }
        }
    }
}
