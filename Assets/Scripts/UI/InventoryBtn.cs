using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InventoryBtn : MonoBehaviour
{
    public GameObject MainInventory;

    public GameObject[] Btn_Menu = new GameObject[INVTAPMOUNT];
    public GameObject[] Cvs_Menu = new GameObject[INVTAPMOUNT];

    const int INVTAPMOUNT = 4;

    private void Awake()
    {
        Inv_Reset();
    }
    
    private void OnDestroy()
    {
        InventoryDisappear();
    }


    /// <summary>
    /// 인벤토리 각 탭 누를떄 해당 탭 제외하고 나머지 비활성화
    /// </summary>
    /// <param name="btn_index"></param>
    public void Open_InvTap(int btn_index)
    {
        for(int i = 0; i<INVTAPMOUNT; i++)
        {
            if (i == btn_index-1)
            {
                Cvs_Menu[i].SetActive(true);
                continue;
            }
            Cvs_Menu[i].SetActive(false);
        }
    }


    /// <summary>
    /// 인벤토리 기본창 띄우게 리셋
    /// </summary>
    public void Inv_Reset()
    {
        Open_InvTap(1);
    }
    
    public void InventoryAppear()
    {
        if (!MainInventory.activeSelf)
        {

            MainInventory.SetActive(true);
            UIManager.Instance.DisableAllUI();
            UIManager.Instance.Joystick.GetComponent<VariableJoystick>().resetController();

            UIManager.Instance.Inventory.SetActive(true);
        }
    }

    public void InventoryDisappear()
    {
        if (MainInventory.activeSelf)
        {
            MainInventory.SetActive(false);
            UIManager.Instance.PeaceOn();

            Inv_Reset();
            UIManager.Instance.Inventory.SetActive(false);
        }
    }
}
