using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using JLib;

public class PuppyStart : JMonoBehaviour
{
    IEnumerator routine = null;
    public void PuppyStartMethod()
    {
        if( null != routine )
        {
            StopCoroutine( routine );
        }

        routine = RoutineStart();
        StartCoroutine( routine );
    }

    IEnumerator RoutineStart()
    {
        GlobalEventParameter p = JLib.ParameterPool.GetParameter<GlobalEventParameter>();
        p.eventName = DefaultEvent.AddScene;
        p.value = "UIScene";
        GlobalEventQueue.EnQueueEvent( p );

        yield return null;

        GlobalEventQueue.EnQueueEvent( DefaultEvent.AddScene, "IntroScene" );
        
    }

    public void OnDestroy()
    {
    }

}
