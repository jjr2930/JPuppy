using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
[Serializable]
public class DogData
{
    public string 이름
    {
        get
        {
            return PlayerPrefs.GetString( "개이름", "멍멍이" );
        }
        set
        {
            PlayerPrefs.SetString( "개이름", value );
            PlayerPrefs.Save();
            _이름 = value;
        }
    }
    public int 배고픔
    {
        get
        {
            return PlayerPrefs.GetInt( "개배고픔", 0 );
        }
        set
        {
            PlayerPrefs.SetInt( "개배고픔", value );
            PlayerPrefs.Save();
            _배고픔 = value;
        }
    }

    public int 심심함
    {
        get
        {
            return PlayerPrefs.GetInt( "개심심함", 0 );
        }
        set
        {
            PlayerPrefs.SetInt( "개심심함", value );
            PlayerPrefs.Save();
            _심심함 = value;
        }
    }

    public int 더러움
    {
        get
        {
            return PlayerPrefs.GetInt( "개더러움",0 );
        }
        set
        {
            PlayerPrefs.SetInt( "개더러움", value );
            PlayerPrefs.Save();
            _더러움 = value;
        }
    }
    public int 졸림
    {
        get
        {
            return PlayerPrefs.GetInt( "개졸림", 0);
        }
        set
        {
            PlayerPrefs.SetInt( "개졸림", value );
            PlayerPrefs.Save();
            _졸림 = value;
        }
    }

    public int 똥마려움
    {
        get
        {
            return PlayerPrefs.GetInt( "개똥마려움", 0 );
        }
        set
        {
            PlayerPrefs.SetInt( "개똥마려움", value );
            PlayerPrefs.Save();
            _똥마려움 = value;
        }
    }
    public int 멋짐
    {
        get
        {
            return PlayerPrefs.GetInt( "개멋짐", 0 );
        }
        set
        {
            PlayerPrefs.SetInt( "개멋짐", value );
            PlayerPrefs.Save();
            _멋짐 = value;
        }
    }

    [SerializeField]
    string _이름;

    [SerializeField]
    int _배고픔;

    [SerializeField]
    int _심심함;

    [SerializeField]
    int _더러움;

    [SerializeField]
    int _졸림;

    [SerializeField]
    int _똥마려움;

    [SerializeField]
    int _멋짐;
}

