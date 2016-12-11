using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserData
{
    [SerializeField]    int actPoint;
    [SerializeField]    int maxActPoint;

    public void AddListener()
    {

    }

    public void ListenUserAction(object param)
    {
        UserActionParamter p = param as UserActionParamter;
        ActPoint -= p.cost;
    }

    public int ActPoint
    {
        get { return actPoint; }
        set
        {
            actPoint = Mathf.Clamp( value, 0, maxActPoint);
            var p = JLib.ParameterPool.GetParameter<UserDataChangeParameter>();
            p.currentValue = actPoint;
            p.maxValue = maxActPoint;
            JLib.GlobalEventQueue.EnQueueEvent(UserDataChange.ActPoint, p);
        }
    }    

    public int MaxActPoint
    {
        get { return maxActPoint; }
        set
        {
            maxActPoint = Mathf.Clamp(value, 0, int.MaxValue);
            var p = JLib.ParameterPool.GetParameter<UserDataChangeParameter>();
            p.currentValue = maxActPoint;
            p.maxValue = maxActPoint;
            JLib.GlobalEventQueue.EnQueueEvent(UserDataChange.MaxActPoint, p);
        }
    }

}
