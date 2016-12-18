using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
[Serializable]
public class DogData
{
    public int 배고픔
    {
        get
        {
            return _배고픔;
        }
        set
        {
            _배고픔 = value;
        }
    }

    public int 심심함
    {
        get
        {
            return _심심함;
        }
        set
        {
            _심심함 = value;
        }
    }

    public int 더러움
    {
        get
        {
            return _더러움;
        }
        set
        {
            _더러움 = value;
        }
    }
    public int 졸림
    {
        get
        {
            return _졸림;
        }
        set
        {
            _졸림 = value;
        }
    }

    public int 똥마려움
    {
        get
        {
            return _똥마려움;
        }
        set
        {
            _똥마려움 = value;
        }
    }
    public int 멋짐
    {
        get
        {
            return _멋짐;
        }
        set
        {
            _멋짐 = value;
        }
    }

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

