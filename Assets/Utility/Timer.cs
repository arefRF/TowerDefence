using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Timer sSingleton;
    private List<TimerStrcut> timer_list_;

    void Start()
    {
        sSingleton = this;
        timer_list_ = new List<TimerStrcut>();
    }
    void Update()
    {
        for(int i=0; i<timer_list_.Count; i++)
        {
            
        }   
    }
    public static void RegisterTimer(Action action, int interval)
    {
        var timer = new TimerStrcut(action, Time.time, interval);
    }

    


    private struct TimerStrcut
    {
        private Action action_;
        private float last_invoke_time_;
        private float interval_;

        public TimerStrcut(Action action, float last_invoke_time, float interval)
        {
            action_ = action;
            last_invoke_time_ = last_invoke_time;
            interval_ = interval;
        }

        public void CheckInvoke()
        {
            if (last_invoke_time_ + interval_ > Time.time) 
            {
                last_invoke_time_ = Time.time;
                action_();
            }
        }
    }
}
