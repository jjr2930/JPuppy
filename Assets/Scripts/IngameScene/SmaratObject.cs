using UnityEngine;
using System;
using System.Collections.Generic;
using JLib;

public class SmaratObject : MonoBehaviour, JISmartObject<SmartObjectType,BallAnimation>
{
    [SerializeField]
    Transform[] actionPoints = null;

    [SerializeField]
    SmartObjectData<SmartObjectType,BallAnimation>[] data = null;

    void Awake()
    {
        actionPoints = transform.GetComponentsInChildren<Transform>();
    }

    public SmartObjectData<SmartObjectType,BallAnimation>[] SmartObjectData
    {
        get { return data; }

    }

    public Transform[] ActionPositions
    {
        get { return actionPoints; }

    }

    public Vector3 RandomActionPosition
    {
        get
        {
            int random = UnityEngine.Random.Range(0,actionPoints.Length);
            return actionPoints[random].position;
        }
    }




    public void OnCollisionEnter( Collision other )
    {
        JSmartObjectParameter<SmartObjectType,BallAnimation> p 
            = ParameterPool.GetParameter<JSmartObjectParameter<SmartObjectType,BallAnimation>>();

        p.actionPostions = ActionPositions;
        p.data = SmartObjectData;
        GlobalEventQueue.EnQueueEvent( DefaultEvent.EnterSmartObject , p );
    }
}
