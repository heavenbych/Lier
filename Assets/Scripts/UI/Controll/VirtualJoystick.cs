using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;         //키보드 마우스 터치를 이벤트로 오브젝트에 보낼 수있음 

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]

    private RectTransform lever;
    private RectTransform rectTransform;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        var inputDir = eventData.position;// - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        var inputDir = eventData.position;// - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDir;
        Debug.Log(inputDir);
        Debug.Log(rectTransform.anchoredPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");
        lever.anchoredPosition = rectTransform.anchoredPosition;
    }
}
