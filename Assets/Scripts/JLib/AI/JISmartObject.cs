using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace JLib
{

    [Serializable]
    public class SmartObjectData
    {
        public SmartObjectType type;
        public List<DogAnimation> animations;
    }
    /// <summary>
    /// Interface for smartObject
    /// </summary>
    public interface JISmartObject
    {
        SmartObjectData[] SmartObjectData { get; }

        Transform[] ActionPositions { get; }

        Vector3 RandomActionPosition { get;}

        void OnCollisionEnter( Collision other );
    }
}