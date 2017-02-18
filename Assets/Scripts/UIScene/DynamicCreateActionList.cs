using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ActionList
{
    public List<string> list = new List<string>();
}
public class DynamicCreateActionList : MonoBehaviour {
    
    //실제로 만들어진 리스트 버튼들
    List<GameObject> actionList = new List<GameObject>();

    //만들 리스트들을 저장한다.
    [SerializeField]
    ActionList playList = null;

    [SerializeField]
    ActionList feedList = null;

    [SerializeField]
    ActionList feeList = null;

    [SerializeField]
    ActionList washList = null;

    [SerializeField]
    ActionList wearList = null;

    [SerializeField]
    ActionList sleepList = null;

    public void ListenClickActionCathegoryButton(object param)
    {
        var p = param as CathegoryClickParameter;
        switch(p.id)
        {
            case UIID.PlayCathegory:
                break;

            case UIID.FeedCathegory:
                break;

            case UIID.ShitCathegory:
                break;

            case UIID.WashCathegory:
                break;

            case UIID.ClothCathegory:
                break;

            case UIID.SleepCathegory:
                break;
        }
    }

    void CreateList(ActionList list)
    {
        while(list.list.Count < actionList.Count)
        {
            string path = JLib.ResourcesTable.GetResourcePath("ActionItem");
            var prefab = Instantiate( JLib.JResources.Load(path)) as GameObject;
            actionList.Add( prefab );
        }
    }

    void CreatePlayList()
    {
        if( playList.list.Count == 0 )
        {
            string json = PlayerPrefs.GetString("밥먹이기리스트","");
            playList = JsonUtility.FromJson<ActionList>( json );
        }
    }

    void CreateFeedList()
    { 

    }

    void CreatePeeList()
    {

    }

    void CreateWashList()
    {

    }

    void CreateWearList()
    {

    }

    void CreateSleepList()
    {

    }
}
