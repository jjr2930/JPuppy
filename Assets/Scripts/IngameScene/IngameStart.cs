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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
