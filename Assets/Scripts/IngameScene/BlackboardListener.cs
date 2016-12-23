using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
public class BlackboardListener : MonoBehaviour
{
    public Blackboard blackBoard= null;
    // Use this for initialization
    void Awake()
    {
        blackBoard = GetComponent<Blackboard>();
        CheckValidation();
        AddListener();
    }

    void AddListener()
    {
        JLib.GlobalEventQueue.RegisterListener(DogDataChange.더러움 , Listen더러움);
        JLib.GlobalEventQueue.RegisterListener(DogDataChange.똥마려움 , Listen똥마려움);
        JLib.GlobalEventQueue.RegisterListener(DogDataChange.배고픔 , Listen배고픔);
        JLib.GlobalEventQueue.RegisterListener(DogDataChange.심심함 , Listen심심함);
        JLib.GlobalEventQueue.RegisterListener(DogDataChange.졸림 , Listen졸림);
    }

    void CheckValidation()
    {
        string desireName = "";
        for( int i = 1 ; i < ( int )DogDesire.Max ; i++ )
        {
            desireName = ( ( DogDesire )i ).ToString() ;
            if( null == blackBoard.GetIntVar( desireName ) )
            {
                var value = blackBoard.AddIntVar();
                value.name = desireName;
                value.Value = 100;
            }
        }
    }

    public void Listen배고픔( object param )
    {
        DogDataChangeParameter p = param as DogDataChangeParameter;
        var intVar = blackBoard.GetIntVar(DogDesire.배고픔.ToString());
        intVar.Value = p.currentPoint;
    }

    public void Listen졸림( object param )
    {
        DogDataChangeParameter p = param as DogDataChangeParameter;
        var intVar = blackBoard.GetIntVar(DogDesire.졸림.ToString());
        intVar.Value = p.currentPoint;
    }

    public void Listen똥마려움( object param )
    {
        DogDataChangeParameter p = param as DogDataChangeParameter;
        var intVar = blackBoard.GetIntVar(DogDesire.똥마려움.ToString());
        intVar.Value = p.currentPoint;
    }

    public void Listen더러움( object param )
    {
        DogDataChangeParameter p = param as DogDataChangeParameter;
        var intVar = blackBoard.GetIntVar(DogDesire.더러움.ToString());
        intVar.Value = p.currentPoint;
    }

    public void Listen심심함( object param )
    {
        DogDataChangeParameter p = param as DogDataChangeParameter;
        var intVar = blackBoard.GetIntVar(DogDesire.심심함.ToString());
        intVar.Value = p.currentPoint;
    }

    void OnDestroy()
    {
        JLib.GlobalEventQueue.RemoveListener(DogDataChange.더러움 , Listen더러움);
        JLib.GlobalEventQueue.RemoveListener(DogDataChange.똥마려움 , Listen똥마려움);
        JLib.GlobalEventQueue.RemoveListener(DogDataChange.배고픔 , Listen배고픔);
        JLib.GlobalEventQueue.RemoveListener(DogDataChange.심심함 , Listen심심함);
        JLib.GlobalEventQueue.RemoveListener(DogDataChange.졸림 , Listen졸림);
    }
}
