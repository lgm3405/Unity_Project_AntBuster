using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject BuildTowerWindowPrefab;

    private Canvas uiCanvas = default;
    private RectTransform buildRect = default;
    private bool isDraging = false;

    private void Awake()
    {
        uiCanvas = GFunc.GetRootObj("DragCanvas").GetComponent<Canvas>();
        buildRect = GetComponent<RectTransform>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        buildRect.anchoredPosition += (eventData.delta / uiCanvas.scaleFactor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이거 함수 만든것 뿐인데 정말로 클릭이 되나???");
    }
}
