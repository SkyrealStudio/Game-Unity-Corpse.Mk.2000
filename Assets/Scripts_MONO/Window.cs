using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Window : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private static Window instance;
    public List<Window> innerWindows;

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
        Debug.Log("Entered:" + name);    
    }
    public void OnPointerExit(PointerEventData eventData)
    {
         Debug.Log("Exited:" + name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Pressed:" + name);
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

    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerData.position,
            canvas.worldCamera,
            out position);
        transform.position = canvas.transform.TransformPoint(position);
    }
}
