using UnityEngine;
using System;
using System.Collections.Generic;
using JLib;
[Serializable]
public class SmartObjectData
{
    public SmartObjectType type;
    public List<DogAnimation> animations;
}
public class SmaratObject : JMonoBehaviour
{
    [SerializeField]
    List<SmartObjectData> data = new List<SmartObjectData>();

    void OnCollisionEnter(Collision other)
    {

    }
}
