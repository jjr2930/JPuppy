using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace JLib
{
    [RequireComponent(typeof(EventTrigger))]
    public abstract class BaseCreateEventForUGUI : JMonoBehaviour
    {
        public List<BaseEventTriggerDataForUGUI> TriggersData
        {
            get
            {
                return triggersData;
            }
            set
            {
                triggersData = value;
            }
        }

        [SerializeField]
        UIID id;

        [SerializeField]
        protected EventTrigger trigger = null;
       
        [SerializeField]
        protected List<BaseEventTriggerDataForUGUI> triggersData = new List<BaseEventTriggerDataForUGUI>();
        

        void Awake()
        {
            if(null == trigger)
            {
                trigger = this.GetComponent<EventTrigger>();
            }

            for(int i =0; i< triggersData.Count; i++)
            {
                CreateNewEntry(triggersData[i]);
            }
        }

        public void CreateNewEntry(BaseEventTriggerDataForUGUI triggerData)
        {
            EventTrigger.Entry newEntry = new EventTrigger.Entry();
            newEntry.eventID = triggerData.type;
            //newEntry.callback = CreateUIEvent;

            if(null == trigger.triggers)
            {
                trigger.triggers = new List<EventTrigger.Entry>();
            }


            trigger.triggers.Add(newEntry);
        }


        public void CreateUIEvent(EventTriggerType type)
        {
            BaseEventTriggerDataForUGUI p = ParameterPool.GetParameter<BaseEventTriggerDataForUGUI>();
            p.type = type;
            GlobalEventQueue.EnQueueEvent(id, type);
        }
    }
}
