using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using JLib;
public class MenuUIManager : JMonoBehaviour, JIUIManager
{
    //[SerializeField]
    //Button startButton = null;

    //[SerializeField]
    //Button developerButton = null;

    //[SerializeField]
    //Button exitIntro = null;

    public void SetActive(bool value)
    {
        gameObject.SetActive( value );
    }

    public void Awake()
    {
        GlobalEventQueue.RegisterListener( DefaultEvent.CompleteLoadScene, ListenSceneChange );

        
        GlobalEventQueue.RegisterListener( UIID.개발자, ListenDeveloperButton );
        GlobalEventQueue.RegisterListener( UIID.시작, ListenIngamebutton );
        GlobalEventQueue.RegisterListener( UIID.종료, ListenExitButton );
    }

    void ListenSceneChange( object name )
    {
        string sceneName = name as string;
        if( "MenuScene" == sceneName )
        {
            gameObject.SetActive( true );
        }
        else
        {
            gameObject.SetActive( false );
        }
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickStart()
    {
        GlobalEventQueue.EnQueueEvent( new GlobalEventParameter
        {
            eventName = DefaultEvent.LoadScene,
            value = "IngameScene"
        } );
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


    public void OnClickDeveloper()
    {
        GlobalEventQueue.EnQueueEvent( new GlobalEventParameter
        {
            eventName = DefaultEvent.LoadScene,
            value = "Developer"
        } );
    }

    void OnDistroy()
    {
        GlobalEventQueue.RemoveListener( DefaultEvent.CompleteLoadScene, ListenSceneChange );
        
        GlobalEventQueue.RemoveListener( UIID.개발자, ListenDeveloperButton );
        GlobalEventQueue.RemoveListener( UIID.시작, ListenIngamebutton );
        GlobalEventQueue.RemoveListener( UIID.종료, ListenExitButton );
    }
}
