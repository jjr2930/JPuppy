using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using JLib;

public class PuppyStart : JMonoBehaviour
{
    public void PuppyStartMethod()
    {
        GlobalEventParameter p = JLib.ParameterPool.GetParameter<GlobalEventParameter>();
        p.eventName = DefaultEvent.AddScene;
        p.value = "UIScene";
        GlobalEventQueue.EnQueueEvent(p);
    }
}
