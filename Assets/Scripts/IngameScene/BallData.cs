using System;
using JLib;
using UnityEngine;
[Serializable]
public class BallData
{
    public const string KEY_NAME = "BALL_NAME";
    public const string KEY_HUNGRY = "BALL_HUNGRY";
    public const string KEY_BORING = "BALL_BORING";
    public const string KEY_DIRTY = "BALL_DIRTY";
    public const string KEY_SLEEPY = "BALL_SLEEPY";
    public const string KEY_SHIT = "BALL_SHIT";
    public const string KEY_RADIUS = "BALL_RADIUS";
    public const string KEY_ELASTICITY = "BALL_ELASTICITY";
    public const string KEY_GLOSS = "BALL_GLOSS";
    public const string KEY_WEIGHT = "BALL_WEIGHT";

    public string Name
    {
        get
        {
            return PlayerPrefs.GetString( KEY_NAME, LocalizeTable.GetLocalString( "기본개이름" ) );
        }
        set
        {
            SetPlayerPref( ref name, BallDataChange.Name, KEY_NAME, value );
        }
    }
    public int Hungry
    {
        get
        {
            return PlayerPrefs.GetInt( KEY_HUNGRY, 0 );
        }
        set
        {
            SetPlayerPref( ref hungry, BallDataChange.Hungry, KEY_HUNGRY, value );
        }
    }

    public int Boring
    {
        get
        {
            return PlayerPrefs.GetInt( KEY_BORING, 0 );
        }
        set
        {
            SetPlayerPref( ref boring, BallDataChange.Boring, KEY_BORING, value );
        }
    }

    public int Dirty
    {
        get
        {
            return PlayerPrefs.GetInt( KEY_DIRTY, 0 );
        }
        set
        {
            SetPlayerPref( ref dirty, BallDataChange.Dirty, KEY_DIRTY, value );
        }
    }
    public int Sleepy
    {
        get
        {
            return PlayerPrefs.GetInt( KEY_SLEEPY, 0 );
        }
        set
        {
            SetPlayerPref( ref sleepy, BallDataChange.Sleepy, KEY_SLEEPY, value );
        }
    }

    public int Shit
    {
        get
        {
            return PlayerPrefs.GetInt( KEY_SHIT, 0 );
        }
        set
        {
            SetPlayerPref( ref shit, BallDataChange.Shit, KEY_SHIT, value );
        }
    }

    public float Radius
    {
        get
        {
            return PlayerPrefs.GetFloat( KEY_RADIUS, GlobalConfigure.Instance.DEFAULT_RADIUS );
        }
        set
        {
            SetPlayerPref( ref radius, BallDataChange.Diameter, KEY_RADIUS, value );
        }
    }

    public float Gloss
    {
        get
        {
            return PlayerPrefs.GetFloat( KEY_GLOSS, GlobalConfigure.Instance.DEFAULT_GLOSS );
        }

        set
        {
            SetPlayerPref( ref gloss, BallDataChange.Gloss, KEY_GLOSS, value );
        }
    }

    public float Elasticity
    {
        get
        {
            return PlayerPrefs.GetFloat( KEY_ELASTICITY, GlobalConfigure.Instance.DEFAULT_ELASTICITY );
        }

        set
        {
            SetPlayerPref( ref elasticity, BallDataChange.Elasticity, KEY_ELASTICITY, value );
        }
    }

    public float Weight
    {
        get
        {
            return PlayerPrefs.GetFloat( KEY_WEIGHT, GlobalConfigure.Instance.DEFAULT_WEIGHT );
        }

        set
        {
            SetPlayerPref( ref weight, BallDataChange.Weight, KEY_WEIGHT, value );
        }
    }

    [SerializeField]
    string name;

    [SerializeField]
    int hungry;

    [SerializeField]
    int boring;

    [SerializeField]
    int dirty;

    [SerializeField]
    int sleepy;

    [SerializeField]
    int shit;

    [SerializeField]
    float radius;

    [SerializeField]
    float gloss;

    [SerializeField]
    float elasticity;

    [SerializeField]
    float weight;

    #region Set PlayerPref
    void SetPlayerPref( ref string member, BallDataChange changeWhat, string key, string value )
    {
        PlayerPrefs.SetString( key, value );
        PlayerPrefs.Save();
        member = value;
        GlobalEventQueue.EnQueueEvent( changeWhat, value );
    }

    void SetPlayerPref( ref int member, BallDataChange changeWhat, string key, int value )
    {
        PlayerPrefs.SetInt( key, value );
        PlayerPrefs.Save();
        member = value;
        GlobalEventQueue.EnQueueEvent( changeWhat, value );
    }

    void SetPlayerPref( ref float member, BallDataChange changeWhat, string key, float value )
    {
        PlayerPrefs.SetFloat( key, value );
        PlayerPrefs.Save();
        member = value;
        GlobalEventQueue.EnQueueEvent( changeWhat, value );
    }
    #endregion
}

