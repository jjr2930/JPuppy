using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using JLib;
public class MenuUIManager : JMonoBehaviour {
    //[SerializeField]
    //Button startButton = null;

    //[SerializeField]
    //Button developerButton = null;

    //[SerializeField]
    //Button exitIntro = null;

    void Awake()
    {
        GlobalEventQueue.RegisterListener(DefaultEvent.ChangeScene, ListenSceneChange);
    }

    void ListenSceneChange(object name)
    {
        string sceneName= name as string;
        if("MenuScene" == sceneName)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickStart()
    {
        GlobalEventQueue.EnQueueEvent(new GlobalEventParameter
        {
            eventName = DefaultEvent.ChangeScene,
            value = "Ingame"
        } );
    }

    public void OnClickDeveloper()
    {
        GlobalEventQueue.EnQueueEvent(new GlobalEventParameter
        {
            eventName = DefaultEvent.ChangeScene,
            value = "Developer"
        } );
    }
}
