using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIListener : MonoBehaviour
{
    [SerializeField]    Slider actPoint = null;
    [SerializeField]    Text actLabel = null;
    [SerializeField]    Text dateLabel = null;

    private void Start()
    {
        JLib.GlobalEventQueue.RegisterListener(UserDataChange.ActPoint, ListenUseActPoint);
        
    }

    public void ListenUseActPoint(object param)
    {
        UserDataChangeParameter p = param as UserDataChangeParameter;
        actPoint.value = (float)p.currentValue / (float)p.maxValue;
        actLabel.text = string.Format("{0}/{1}", p.currentValue, p.maxValue);

        int usePoint = p.maxValue - p.currentValue;
        int date = usePoint / 24;
        int hour = usePoint % 24;

        dateLabel.text = string.Format("{0:D3}일차 {1:D3}시간", date, hour);

        JLib.ParameterPool.ReturnPool(p);
    }
}
