using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour       //플레이어와 포탈간 상호 작용 적용하는 스크립트
{
    private bool isStage1Done = false;
    public bool check = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.transform.parent.gameObject.name == "Stage1 EndPortal")
            && !isStage1Done)
        {
            //    check = true;
            //    LoadManager.Instance.StartLoad("Test Scene", "New Scene");
            isStage1Done = true;
            GameObject.Find("Level").transform.Find("Area 1").gameObject.SetActive(false);
            GameObject.Find("Level").transform.Find("Area 2").gameObject.SetActive(true);
            collision.transform.parent.gameObject.SetActive(false);

        }
            


    }
}
