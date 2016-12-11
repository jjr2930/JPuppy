using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JLib;
public class IntroUIManager : JMonoBehaviour
{
    [SerializeField]
    TweenFontColor myName = null;

    [SerializeField]
    TweenFontColor gameName = null;

    void Awake()
    {
        GlobalEventQueue.RegisterListener( DefaultEvent.ChangeScene , ListenChangeScene );
        gameObject.SetActive( true );
        myName.enabled = true;
    }

    public void ListenChangeScene( object obj )
    {
        string name = obj as string;
        if( "IntroScene" == name )
        {
            gameObject.SetActive( true );
        }
        else
        {
            gameObject.SetActive( false );
        }
    }
    public void UnloadScene(string sceneName)
    {
        GlobalEventQueue.EnQueueEvent(new GlobalEventParameter()
        {
            eventName = DefaultEvent.UnloadScene,
            value = sceneName
        } );
    }
    public void ChangeScene( string sceneName )
    {
        if( !string.IsNullOrEmpty( sceneName ) )
        {
            GlobalEventQueue.EnQueueEvent( new GlobalEventParameter()
            {
                eventName = DefaultEvent.ChangeScene ,
                value = sceneName
            } );
        }
        else
        {
            Debug.LogErrorFormat( "IntroUIManager.ChangeScen => {0} is not string" , sceneName );
        }
    }

    public void ShowGameName()
    {
        myName.enabled = false;
        gameName.enabled = true;

    }

    void OnDistroy()
    {
        GlobalEventQueue.RemoveListener(DefaultEvent.ChangeScene, ListenChangeScene);
    }
}
