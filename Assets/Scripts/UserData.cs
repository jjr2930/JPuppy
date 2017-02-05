using UnityEngine;
using System.Collections;

[System.Serializable]
public class UserData : JLib.MonoSingle<UserData>
{
    public int ActPoint
    {
        get
        {
            return PlayerPrefs.GetInt( "행동력", 1000 );
        }
        set
        {
            value = Mathf.Clamp( value, 0, MaxActPoint );
            actPoint = value;
            PlayerPrefs.SetInt( "행동력", value );
            PlayerPrefs.Save();
            var p = JLib.ParameterPool.GetParameter<UserDataChangeParameter>();
            p.currentValue = actPoint;
            p.maxValue = MaxActPoint;
            JLib.GlobalEventQueue.EnQueueEvent( UserDataChange.ActPoint, p );
        }
    }

    public int MaxActPoint
    {
        get
        {
            return PlayerPrefs.GetInt( "행동력제한", 1000 );
        }
        set
        {
            value = Mathf.Clamp( value, 0, int.MaxValue );
            maxActPoint = value;
            PlayerPrefs.SetInt( "행동력제한", value );
            PlayerPrefs.Save();
            var p = JLib.ParameterPool.GetParameter<UserDataChangeParameter>();
            p.currentValue = MaxActPoint;
            p.maxValue = MaxActPoint;
            JLib.GlobalEventQueue.EnQueueEvent( UserDataChange.MaxActPoint, p );
        }
    }

    public BallData BallDataㅠ
    {
        get
        {
            return ballData;
        }
    }

    [SerializeField]
    int actPoint;

    [SerializeField]
    int maxActPoint;

    [SerializeField]
    BallData ballData;

    private void Awake()
    {
        ballData = new BallData();
    }

    public void ListenUserAction( object param )
    {
        UserActionParamter p = param as UserActionParamter;
        ActPoint -= p.cost;
    }


}
