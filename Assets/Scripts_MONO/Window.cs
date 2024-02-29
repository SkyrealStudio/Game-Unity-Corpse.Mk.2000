using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private static Window instance;
    public List<Window> innerWindows;
    private Vector2 dragOffset;
    //public Button button;

    public IPointerClickHandler controllerClose;

    void Start()
    {
        if (!instance)
        {
            instance = this;
            innerWindows = new();
        }
    }
    
    public void OnWindowClose()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Entered:" + name);    
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Exited:" + name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("Pressed:" + name);
        }
    }

    void Update()
    {
        if (!instance)
        {
            instance = this;
            //do something
        }
    }

    public Canvas canvas;

    public void BeginDragHandler(BaseEventData data)
    {
        Debug.Log("BeginDrag!");
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 mouseRectPosition;
        //get rect position of the mouse in the canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out mouseRectPosition);

        dragOffset = mouseRectPosition - (Vector2)GetComponent<RectTransform>().localPosition;
        Debug.Log("BeginDrag - OffsetPosition:" + dragOffset);
    }
    
    public void DragHandler(BaseEventData data)
    //Used by EventTrigger as a component dddd
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 mouseRectPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out mouseRectPosition);

        transform.position = canvas.transform.TransformPoint(mouseRectPosition-dragOffset);
    }
    public void EndDragHandler(BaseEventData data)
    {
        Debug.Log("EndDrag!");
    }
}
