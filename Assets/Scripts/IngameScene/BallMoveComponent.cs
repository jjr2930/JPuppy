using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JLib;
/// <summary>
/// 공의 움직임을 위한 컴포넌트
/// </summary>
public class BallMoveComponent : MonoBehaviour {
    public string ballName = "Ball";
    Transform cachedTrans = null;   //성능을 위해 캐시한다.
    Transform ball = null; //성능을 위해 캐시한다.

	// Use this for initialization
	void Awake()
    {
        cachedTrans = transform;
        cachedTrans.FindChildUsingTraversal( ballName );
    }
	// Update is called once per frame
	void Update () {
		
	}
}
