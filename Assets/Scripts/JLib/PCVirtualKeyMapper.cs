using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace JLib
{
    [Serializable]
    public class PCVirtualKeyMapData
    {
        public KeyCode keyboardKey;
        public VK_Enum virtualKey;
    }
    public class PCVirtualKeyMapper : MonoSingle<PCVirtualKeyMapper>
    {
        [SerializeField]
        List<PCVirtualKeyMapData> mappingList
            = new List<PCVirtualKeyMapData>();

        void Update()
        {
            for(int i =0; i<mappingList.Count; i++)
            {
                if(Input.GetKeyDown(mappingList[i].keyboardKey))
                {
                    GlobalEventParameter param = new GlobalEventParameter();
                    param.eventName = VK_State.Down;
                    param.value = mappingList[i].virtualKey;

                    GlobalEventQueue.EnQueueEvent(param);
                }

                if(Input.GetKey(mappingList[i].keyboardKey))
                {
                    GlobalEventParameter param = new GlobalEventParameter();
                    param.eventName = VK_State.Press;
                    param.value = mappingList[i].virtualKey;

                    GlobalEventQueue.EnQueueEvent(param);
                }

                if(Input.GetKeyUp(mappingList[i].keyboardKey))
                {
                    GlobalEventParameter param = new GlobalEventParameter();
                    param.eventName = VK_State.Up;
                    param.value = mappingList[i].virtualKey;

                    GlobalEventQueue.EnQueueEvent(param);
                }
            }
        }
    }
}
