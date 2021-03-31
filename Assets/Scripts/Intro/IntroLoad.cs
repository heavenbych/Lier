using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoad : MonoBehaviour
{
    public Slider slider;
    bool IsDone = false;
    float fTime = 0f;
    bool IsStart = false;

    AsyncOperation async_operation;

    private void Awake()
    {
        System.GC.Collect();
    }
    private void Start()
    {
        
    }

    public void gameStart()
    {
        IsStart = true;
        UIManager.Instance.DisableAllUI();
        StartCoroutine(StartLoad("Char"));
        GameManager.Instance.GameStatus = GameStatus.Character;
    }
    private void Update()
    {
        if (IsStart)
        {
            fTime += Time.deltaTime;
            slider.value = fTime;

            if (fTime >= 1)
                async_operation.allowSceneActivation = true;
        }
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
