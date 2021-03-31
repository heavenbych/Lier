using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//공용으로 사용하는 오브젝트에 부여하는 파괴 방지 및 중복 생성 방지 스크립트
public class NeverDestroy : MonoBehaviour
{
    public bool exist = false;
    private void Awake()
    {
        if (GameObject.Find(gameObject.name).GetComponent<NeverDestroy>().exist)
        {
            Destroy(this.gameObject);
            return;
        }
        exist = true;

        DontDestroyOnLoad(this.gameObject);
    }
}
