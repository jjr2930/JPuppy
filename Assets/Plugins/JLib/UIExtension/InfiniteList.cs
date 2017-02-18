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

    public interface IItemData
    {

    }

    public interface IItem 
    {
        IItemData GetData();
        void SetData( IItemData data );
        RectTransform rectTransform { get; }
    }

    public class InfiniteList : JMonoBehaviour
    {
        public int countOfSee;
        public ScrollRect scrollRect = null;
        public IItem Prefab = null;
        public List<IItem> items = new List<IItem>();
        public string path = "";
        public Transform contents = null;

        List<IItemData> itemData = null;
        RectTransform transScrollRect = null;
        //디버깅을 위해 보여야함
        [SerializeField]
        int lastIndex;

        [SerializeField]
        int firstIndex;

        [SerializeField]
        int itemCount;

        [SerializeField]
        int createdCount;


        public void ListenClickCathegory(object param)
        {
           
        }
        void Awake()
        {
            transScrollRect = scrollRect.transform as RectTransform;
            createdCount = countOfSee + 2;
        }

        void Start()
        {
            UnityEngine.Object obj = JResources.Load( path );
            for (int i = 0; i < createdCount; i++)
            {
                GameObject instance = Instantiate( obj ) as GameObject;
                IItem item = instance.GetComponent<IItem>();
                items.Add( item );
                instance.transform.parent = contents;
            }
        }

        void LateUpdate()
        {
            var where = WhereCollision();
            switch( where )
            {
                case CollisionPosition.Left:
                    lastIndex = Mathf.Clamp( ++lastIndex, 0, items.Count - 1 );
                    InsertItemDataToItem( items[0], itemData[lastIndex] );
                    MoveLeftEndToRightEnd();
                    break;

                case CollisionPosition.Right:
                    firstIndex = Mathf.Clamp( --firstIndex, 0, items.Count - 1 );
                    InsertItemDataToItem( items.GetLast(), itemData[firstIndex] );
                    MoveRightEndToLeftEnd();
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
            //drag to right and contact rightlimit
            if(items[items.Count - 2].rectTransform.rect.xMin<  transScrollRect.rect.xMax
                && scrollRect.velocity.x >=0 )
            {
                return CollisionPosition.Right;
            }

            return CollisionPosition.None;            
        }

        void InsertItemDataToItem(IItem item, IItemData data)
        {
            item.SetData( data );
        }
    }
}
