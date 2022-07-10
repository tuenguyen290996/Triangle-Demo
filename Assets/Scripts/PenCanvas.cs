using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenCanvas : MonoBehaviour, IPointerClickHandler
{
    public Action OnPenCanvasleftClickEvent;

    public void OnPointerClick(PointerEventData eventData)
    {
        //Left Click
        if (eventData.pointerId == -1)
        {
            OnPenCanvasleftClickEvent?.Invoke();
        }

    }
}
