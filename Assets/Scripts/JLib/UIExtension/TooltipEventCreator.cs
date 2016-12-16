using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JLib;
public class TooltipEventCreator : IBeginDragHandler, IEndDragHandler
{
    [SerializeField]
    string localKey = "";
    public void OnBeginDrag( PointerEventData eventData )
    {
        TooltipParameter p = ParameterPool.GetParameter<TooltipParameter>();
        p.localKey = localKey;
        p.position = eventData.pressPosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GlobalEventQueue.EnQueueEvent( DefaultEvent.HideTooltip, null);
    }
}
