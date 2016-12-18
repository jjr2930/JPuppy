using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using JLib;
public class ExitUIManager : JMonoBehaviour, JLib.JIUIManager
{
    public void Awake()
    {
        Debug.Log( "ExitUIManager Awake is nothing to do" );
    }

    public void SetActive( bool value )
    {
        gameObject.SetActive( false );
    }
}

