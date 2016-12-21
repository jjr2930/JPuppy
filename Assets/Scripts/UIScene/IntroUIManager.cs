using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JLib;
public class IntroUIManager : JMonoBehaviour, JIUIManager
{
    [SerializeField]
    TweenFontColor myName = null;

    [SerializeField]
    TweenFontColor gameName = null;

    public void SetActive( bool value )
    {
        gameObject.SetActive( value );
    }

    public void Awake()
    {
        GlobalEventQueue.RegisterListener( DefaultEvent.CompleteLoadScene, ListenSceneLoadComplete );
        myName.enabled = true;
    }

    public void ListenSceneLoadComplete( object obj )
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
    public void UnloadScene( string sceneName )
    {
        GlobalEventQueue.EnQueueEvent( new GlobalEventParameter()
        {
            eventName = DefaultEvent.UnloadScene,
            value = sceneName
        } );
    }
    public void AddScene( string sceneName )
    {
        if( !string.IsNullOrEmpty( sceneName ) )
        {
            GlobalEventQueue.EnQueueEvent( new GlobalEventParameter()
            {
                eventName = DefaultEvent.AddScene,
                value = sceneName
            } );
        }
        else
        {
            Debug.LogErrorFormat( "IntroUIManager.ChangeScen => {0} is not string", sceneName );
        }
    }

    public void ShowGameName()
    {
        myName.enabled = false;
        gameName.enabled = true;

    }

    void OnDistroy()
    {
        GlobalEventQueue.RemoveListener( DefaultEvent.CompleteLoadScene, ListenSceneLoadComplete );
    }
}
