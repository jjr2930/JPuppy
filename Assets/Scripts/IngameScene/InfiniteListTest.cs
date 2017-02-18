using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using JLib;
public class InfiniteListTest : MonoBehaviour
{
    JLib.InfiniteList list = null;
    private void Awake()
    {
        list = FindObjectOfType<InfiniteList>();
    }
    private void OnGUI()
    {
        if(GUILayout.Button("Test"))
        {
            List<IItemData> list = new List<IItemData>();
            for(int i = 0; i< 30; i++)
            {
                ActionButtonData newData = new ActionButtonData();
                newData.imgName = "";
                newData.localName = "피자";
                newData.actPoint = 0;
                list.Add( newData );
            }

            ScrollRectSetItemParameter p 
                = ParameterPool.GetParameter<ScrollRectSetItemParameter>();
            p.itemList = list;
            p.UIID = this.list.id;

            GlobalEventQueue.EnQueueEvent( DefaultEvent.SetItemScrollRect, p );
        }
    }
}

