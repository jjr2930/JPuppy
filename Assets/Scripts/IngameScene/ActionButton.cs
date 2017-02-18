using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JLib;
using System;

public class ActionButton : JLib.JMonoBehaviour, JLib.IItem
{
    public Image thumbnail = null;
    public LocalizeTextForUGUI localComponent = null;
    RectTransform IItem.rectTransform
    {
        get
        {
            return rectTransform;
        }
    }

    public IItemData GetData()
    {
        return data;
    }

    public void SetData( IItemData data )
    {
        this.data = data as ActionButtonData;
        thumbnail.sprite = JResources.Load( this.data.imgName ) as Sprite;
        localComponent.Key = this.data.localName;
    }

    ActionButtonData data = null;
    
}
