using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using JLib;
public class DogCreateEventForUGUI : MonoBehaviour
{
    [SerializeField]
    UIID id = UIID.None;

    [SerializeField]
    EventTriggerType type = EventTriggerType.Cancel;
     
    public void CreateEvent()
    {
        DogUIEventParameter p = ParameterPool.GetParameter<DogUIEventParameter>();
        p.type = type;
        GlobalEventQueue.EnQueueEvent( id , p );
        Debug.LogFormat( "id : {0}, type : {1}" , id , type );
    }
}

