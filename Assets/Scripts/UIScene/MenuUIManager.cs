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

    public void OnClickDeveloper()
    {
        GlobalEventQueue.EnQueueEvent( new GlobalEventParameter
        {
            eventName = DefaultEvent.LoadScene,
            value = "Developer"
        } );
    }
}
