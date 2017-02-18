using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DesireData
{
    public BallDesire desire;
    public AnimationCurve curve;
}
public class DogDesireScheduler : MonoBehaviour
{
    [SerializeField]
    List<DesireData> desireCurve = new List<DesireData>();
    [SerializeField]
    BallData dogData = null;

    private void Awake()
    {
        dogData = UserData.Instance.BallData;
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
                case BallDesire.더러움:
                    dogData.Dirty -= ( int )value;
                    break;

                case BallDesire.똥마려움:
                    dogData.Shit -= ( int )value;
                    break;

                case BallDesire.배고픔:
                    dogData.Hungry -= ( int )value;
                    break;

                case BallDesire.심심함:
                    dogData.Boring -= ( int )value;
                    break;

                case BallDesire.졸림:
                    dogData.Sleepy -= ( int )value;
                    break;

            }
        }
    }


}
