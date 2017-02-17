using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace JLib
{
    public interface ItemData
    {

    }
    public interface Item
    {
        void SetData( ItemData data);
    }
    public interface IItemList
    {
        int Count { get; set; }
        Item Next { get; set; }
    }
    public class JInifiniteList : JMonoBehaviour
    {
        /// <summary>
        /// 리스트가 보여줄 아이템 갯수
        /// </summary>
        public int countOfSee;
        

    }
}