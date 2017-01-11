using UnityEngine;
using System.Collections;
using JLib;
public class IngameStart : JMonoBehaviour {

	// Use this for initialization
	void Start () {
	    GlobalEventQueue.EnQueueEvent(new GlobalEventParameter()
        {
            eventName = DefaultEvent.IngameLoadingComplete,
            value = null
        } );

        UserData.Instance.ActPoint = UserData.Instance.ActPoint;
        StartCoroutine(IfLoadUI());
	}

    public IEnumerator IfLoadUI()
    {
        var checker = GameObject.FindObjectOfType<JUIManagerInitializer>();
        if(checker == null)
        {
            GlobalEventQueue.EnQueueEvent( DefaultEvent.AddScene, "UIScene");
            yield return null;
            GlobalEventQueue.EnQueueEvent( DefaultEvent.CompleteLoadScene, "IngameScene");
        }


    }
	// Update is called

}
