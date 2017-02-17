using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace JLib
{
    public enum CollisionPosition
    {
        None,
        Left,
        Right
    }

    public interface iItemData
    {

    }

    public interface iItem 
    {
        void SetData( iItemData data );
        RectTransform rectTransform { get; set; }
    }

    public class InfiniteList : JMonoBehaviour
    {
        public int countOfSee;
        public ScrollRect scrollRect = null;

        RectTransform transScrollRect = null;

        List<iItem> items = null;
        void Awake()
        {
            transScrollRect = scrollRect.transform as RectTransform;
        }

        void LateUpdate()
        {
            var where = WhereCollision();
            switch( where )
            {
                case CollisionPosition.Left:
                    break;

                case CollisionPosition.Right:
                    break;

                case CollisionPosition.None:
                    //do nothing
                    break;

                default:
                    Debug.LogErrorFormat( "{0} is not supported yet" , where.ToString() );
                    break;
            }
        }

        void MoveLeftEndToRightEnd()
        {
            items[ 0 ].rectTransform.SetAsLastSibling();
        }

        void MoveRightEndToLeftEnd()
        {
            items[ items.Count - 1 ].rectTransform.SetAsFirstSibling();
        }

        CollisionPosition WhereCollision()
        {
            //drag to left and contact leftLimit
            if(items[1].rectTransform.rect.xMax <  transScrollRect.rect.xMin
                && scrollRect.velocity.x < 0 )
            {
                return CollisionPosition.Left;
            }

            if(items[items.Count - 2].rectTransform.rect.xMin<  transScrollRect.rect.xMax
                && scrollRect.velocity.x >=0 )
            {
                return CollisionPosition.Right;
            }

            return CollisionPosition.None;            
        }
    }
}
