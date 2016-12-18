using UnityEngine;
using System.Collections;

public enum UserDataChange
{
    None,
    ActPoint,
    MaxActPoint,    
}

public enum DoAction
{
    None,
    밥먹이기,
    재우기,
    씻기기,
    놀아주기,
    배변치우기
}

public enum DogDesire
{
    배고픔,
    심심함,
    더러움,
    졸림,
    똥마려움,
}
public enum UIID
{
    None,
    //Menu
    시작,
    개발자,
    종료,

    //Ingame
    밥먹이기버튼,
    재우기버튼,
    씻기기버튼,
    놀아주기버튼,
    배변치우기버튼,
    옷입히기버튼

    
}

public enum DogUI
{
    None,
    ShowCommonPopup,
}




public enum SmartObjectType
{
    None = 0,
    Sleep,
    Feed,
    Pee,
    Bath,
    Play
}

public enum DogAnimation
{
    None = 0,
    졸려,
    배고파,
    오줌마려,
    씻고싶어,
    놀고싶어,
    자기,
    밥먹기,
    오줌누기,
    씻기,
    놀기
}