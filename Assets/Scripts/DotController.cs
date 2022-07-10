using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DotController : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    public Action<DotController> OnDragEvent;

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public Action<DotController> OnRightClickEvent;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -2)
        {
            //Right Click
            OnRightClickEvent?.Invoke(this);
        }

    }
}
