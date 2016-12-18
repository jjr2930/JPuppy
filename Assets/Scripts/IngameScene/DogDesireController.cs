using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DesireData
{
    public DogDesire desire;
    public AnimationCurve curve;
}
public class DogDesireController : MonoBehaviour
{
    [SerializeField]
    List<DesireData> desireCurve = new List<DesireData>();

    /// <summary>
    /// 행동량을 이용하여 시간의 변화를 본다.
    /// </summary>
    /// <param name="param"></param>
    public void ListenChangeActPointForHour(object param)
    {
        UserDataChangeParameter p = param as UserDataChangeParameter;
        int hour = p.currentValue % 24;        
    }


    public void LoadCurveDataFromTable()
    {

    }
}
