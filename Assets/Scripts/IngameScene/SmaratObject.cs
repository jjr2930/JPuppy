using UnityEngine;
using System;
using System.Collections.Generic;
using JLib;

public class SmaratObject : JMonoBehaviour, JISmartObject
{
    [SerializeField]
    Transform[] actionPoints = null;

    [SerializeField]
    SmartObjectData[] data = null;

    void Awake()
    {
        actionPoints = transform.GetComponentsInChildren<Transform>();
    }

    public SmartObjectData[] SmartObjectData
    {
        get { return data; }

    }

    public Transform[] ActionPositions
    {
        get { return actionPoints; }

    }

    public void OnCollisionEnter( Collision other )
    {
        JSmartObjectParameter p = ParameterPool.GetParameter<JSmartObjectParameter>();
        p.actionPostions = ActionPositions;
        p.data = SmartObjectData;
        GlobalEventQueue.EnQueueEvent( DefaultEvent.EnterSmartObject , p );
    }
}
