using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JLib;
public class DogCreateEventForUGUI : EventTrigger
{
    [SerializeField]
    UIID id;
    public override void OnSelect(BaseEventData eventData)
    {
        Debug.LogFormat("OnSelected {0}", id);
        JUIEventParameter p = ParameterPool.GetParameter<JUIEventParameter>();
        p.type = EventTriggerType.Select;
        GlobalEventQueue.EnQueueEvent(id, p);
    }

}

