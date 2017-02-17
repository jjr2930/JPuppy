using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using JLib;
/// <summary>
/// 공의 움직임을 위한 컴포넌트
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class BallMoveComponent : JMonoBehaviour {
    public string ballName = "Ball";
    public float rollingSpeed = 10f;
    Transform ball = null; //성능을 위해 캐시한다.
    NavMeshAgent navAgent = null;
    IEnumerator coroutine = null;
	// Use this for initialization
	void Awake()
    {
        ball = transform.FindChildUsingTraversal( ballName );
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        GlobalEventQueue.RegisterListener( BallAction.Move , ListenBallMove );
        GlobalEventQueue.RegisterListener( BallAction.Stop , ListenStopBall );
    }

    void OnDestroy()
    {
        GlobalEventQueue.RemoveListener( BallAction.Move , ListenBallMove );
        GlobalEventQueue.RemoveListener( BallAction.Stop , ListenStopBall );
    }

    /// <summary>
    /// 움직여라 라는 이벤트를 듣는다.
    /// </summary>
    /// <param name="param">BallMoveParameter</param>
    public void ListenBallMove(object param)
    {
        BallMoveParameter p = param as BallMoveParameter;

        navAgent.SetDestination( p.position );

        coroutine = BallRotate();
        StartCoroutine( coroutine );
    }

    /// <summary>
    /// 멈추라는 이벤트를 듣는다.
    /// </summary>
    /// <param name="param"></param>
    public void ListenStopBall(object param)
    {
        navAgent.Stop();
        if(null != coroutine)
        {
            StopCoroutine( coroutine );
        }
    }
    IEnumerator BallRotate()
    {
        while(true)
        {
            yield return null;
            ball.Rotate( ball.right , rollingSpeed * JTime.DeltaTime );
        }
    }
}
