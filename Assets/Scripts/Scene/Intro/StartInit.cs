using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인트로 화면 초기화 스크립트
public class StartInit : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
