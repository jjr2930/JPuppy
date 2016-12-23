using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DesireData
{
    public DogDesire desire;
    public AnimationCurve curve;
}
public class DogDesireScheduler : MonoBehaviour
{
    [SerializeField]
    List<DesireData> desireCurve = new List<DesireData>();
    [SerializeField]
    DogData dogData = null;

    private void Awake()
    {
        dogData = UserData.Instance.DogData;
    }

    /// <summary>
    /// 행동량을 이용하여 시간의 변화를 본다.
    /// </summary>
    /// <param name="param">UserDataChangeParameter </param>
    public void ListenChangeActPointForHour( object param )
    {
        UserDataChangeParameter p = param as UserDataChangeParameter;
        int hour = p.currentValue % 24;
        for( int i = 0; i < desireCurve.Count; i++ )
        {
            float value = desireCurve[ i ].curve.Evaluate( hour );
            switch( desireCurve[ i ].desire )
            {
                case DogDesire.더러움:
                    dogData.더러움 -= ( int )value;
                    break;

                case DogDesire.똥마려움:
                    dogData.똥마려움 -= ( int )value;
                    break;

                case DogDesire.배고픔:
                    dogData.배고픔 -= ( int )value;
                    break;

                case DogDesire.심심함:
                    dogData.심심함 -= ( int )value;
                    break;

                case DogDesire.졸림:
                    dogData.졸림 -= ( int )value;
                    break;

            }
        }
    }


}
