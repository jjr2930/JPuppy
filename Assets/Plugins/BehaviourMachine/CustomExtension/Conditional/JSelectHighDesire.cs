using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;
using System;

public class JSelectHighDesire : BehaviourMachine.ActionNode
{
    public int selectedValue;
    public override void Awake()
    {
        base.Awake();
    }

    public override Status Update()
    {
        return Status.Success;
    }
}
