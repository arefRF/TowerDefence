using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hive.Projectile;

public class Timer : MonoBehaviour
{
    public static Timer sSingleton;
    private static int counter = 1;
    private List<TimerInstanceBase> timer_list_;

    void Start()
    {
        sSingleton = this;
        timer_list_ = new List<TimerInstanceBase>();
    }
    void Update()
    {
        bool remove_from_list_;
        for(int i=0; i<timer_list_.Count; i++)
        {
            timer_list_[i].CheckInvoke(out remove_from_list_);
            if(remove_from_list_)
            {
                timer_list_.RemoveAt(i);
                i--;
            }
        }   
    }

    public static void UnregisterTimer(int id)
    {
        for(int i=0; i<sSingleton.timer_list_.Count; i++)
        {
            if(sSingleton.timer_list_[i].pId == id)
            {
                sSingleton.timer_list_.RemoveAt(i);
                return;
            }
        }
        Debug.LogError("timer not found. id: " + id);
    }

    public static void RegisterTimer_TowerattackEvent(TowerAttackEventHandler action, float interval, int call_count, ProjectileBase projectile, out int id)
    {
        id = counter;
        counter++;
        var timer = new TimerInstance_TowerAttackEvent(action, Time.time, interval, call_count, id, projectile);
        sSingleton.timer_list_.Add(timer);
    }

    public static void RegisterTimer_NoArgumentEvent(Delegate_NoArgument action, float interval, int call_count, out int id)
    {
        id = counter;
        counter++;
        var timer = new TimerInstance_NoArgumentEvent(action, Time.time, interval, call_count, id);
        sSingleton.timer_list_.Add(timer);
    }


    private class TimerInstanceBase
    {
        
        private float last_invoke_time_;
        private float interval_;
        private int call_count_;
        private int id_;
        public int pId { get { return id_; } }
        

        public TimerInstanceBase(float last_invoke_time, float interval, int call_count, int id)
        {
            last_invoke_time_ = last_invoke_time;
            interval_ = interval;
            call_count_ = call_count;
            id_ = id;   
        }

        public void CheckInvoke(out bool remove_from_list)
        {
            remove_from_list = false;
            if (last_invoke_time_ + interval_ < Time.time) 
            {
                last_invoke_time_ = Time.time;
                if(call_count_ > 0)
                    call_count_--;
                Invoke();
                if(call_count_ == 0)
                    remove_from_list = true;
            }
        }
        
        protected virtual void Invoke() { }
    }

    private class TimerInstance_TowerAttackEvent : TimerInstanceBase
    {
        private ProjectileBase projectile_;
        private TowerAttackEventHandler action_;

        public TimerInstance_TowerAttackEvent(TowerAttackEventHandler action, float last_invoke_time, float interval, int call_count, int id, ProjectileBase projectile)
        : base(last_invoke_time, interval, call_count, id)
        {
            projectile_ = projectile;
            action_ = action;
        }

        protected override void Invoke()
        {
            action_(projectile_);
        }
    }

    private class TimerInstance_NoArgumentEvent : TimerInstanceBase
    {
        private Delegate_NoArgument action_;

        public TimerInstance_NoArgumentEvent(Delegate_NoArgument action, float last_invoke_time, float interval, int call_count, int id)
        : base(last_invoke_time, interval, call_count, id)
        {
            action_ = action;
        }

        protected override void Invoke()
        {
            action_();
        }
    }
}
