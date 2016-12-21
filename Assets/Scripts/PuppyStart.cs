using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using JLib;

public class PuppyStart : JMonoBehaviour
{
    IEnumerator routine = null;
    public void PuppyStartMethod()
    {
        GlobalEventQueue.RegisterListener( UIID.개발자, ListenDeveloperButton );
        GlobalEventQueue.RegisterListener( UIID.시작, ListenIngamebutton );
        GlobalEventQueue.RegisterListener( UIID.종료, ListenExitButton );
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

    public void ListenDeveloperButton( object param )
    {
        GlobalEventQueue.EnQueueEvent( DefaultEvent.LoadScene, "DeveloperScene" );
    }

    public void ListenExitButton( object param )
    {
        GlobalEventQueue.EnQueueEvent( DefaultEvent.LoadScene, "ExitScene" );
    }

    public void ListenIngamebutton( object param )
    {
        GlobalEventQueue.EnQueueEvent( DefaultEvent.LoadScene, "IngameScene" );
    }

    public void OnDestroy()
    {
        GlobalEventQueue.RemoveListener( UIID.개발자, ListenDeveloperButton );
        GlobalEventQueue.RemoveListener( UIID.시작, ListenIngamebutton );
        GlobalEventQueue.RemoveListener( UIID.종료, ListenExitButton );
    }

}
