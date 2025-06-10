using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPanel : ControllerPanel, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        pressed = true;
        fingerId = eventData.pointerId;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pressed = false;
        fingerId = eventData.pointerId;
    }

}
