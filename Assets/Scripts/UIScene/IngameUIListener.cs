using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIListener : MonoBehaviour
{
    [SerializeField]
    Slider actPoint = null;
    [SerializeField]
    Text actLabel = null;
    [SerializeField]
    Text dateLabel = null;

    private void Start()
    {
        JLib.GlobalEventQueue.RegisterListener( UserDataChange.ActPoint , ListenUseActPoint );

    }

    public void ListenUseActPoint( object param )
    {
        UserDataChangeParameter p = param as UserDataChangeParameter;
        actPoint.value = ( float )p.currentValue / ( float )p.maxValue;
        actLabel.text = string.Format( "{0}/{1}" , p.currentValue , p.maxValue );

        int usePoint = p.maxValue - p.currentValue;
        int date = usePoint / 24;
        int hour = usePoint % 24;
        string localDate = JLib.LocalizeTable.GetLocalString("일차");
        string localHour= JLib.LocalizeTable.GetLocalString("시");
        dateLabel.text = string.Format( "{0:D3}{1} {2:D3}{3]" , date , localDate , hour , localHour );

        JLib.ParameterPool.ReturnPool( p );
    }
}
