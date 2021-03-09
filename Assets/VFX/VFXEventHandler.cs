using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXEventHandler : MonoBehaviour
{
    [SerializeField]
    private List<EventTimePair> events_list_;

    private float start_time_;
    
    void Start()
    {
        start_time_ = Time.time;
    }
    void Update()
    {
        for(int i=0; i < events_list_.Count; i++)
        {
            if(events_list_[i].pTime + start_time_ < Time.time)
            {
                events_list_[i].InvokeEvent();
                events_list_.RemoveAt(i);
                i--;
            }            
        }
    }

    public void RegisterEvent(VFXEventCallback callback, VFXEventEnum event_enum)
    {
        for(int i=0; i < events_list_.Count; i++)
        {
            if(events_list_[i].pEventEnum == event_enum)
            {
                events_list_[i].pCallBack += callback;
            }            
        }
    }
}

public delegate void VFXEventCallback();

public enum VFXEventEnum
{
    DoDamage
}

[System.Serializable]
public class EventTimePair 
{
    public VFXEventEnum pEventEnum;
    public float pTime;
    public event VFXEventCallback pCallBack;

    public EventTimePair(VFXEventEnum event_enum, float time)
    {
        pEventEnum = event_enum;
        pTime = time;
    }

    public void InvokeEvent()
    {
        pCallBack?.Invoke();
    }
}
