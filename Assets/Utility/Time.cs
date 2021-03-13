using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time : MonoBehaviour
{
    public static float time;
    public static float timeWithCeaseFire;
    public static float deltaTime;
    public static float deltaTimeWithCeaseFire;
    public static float timeScale;

    private static bool is_cease_fire_;
    void Start()
    {
        time = UnityEngine.Time.time;
        timeWithCeaseFire = time;
        deltaTime = UnityEngine.Time.deltaTime;
        deltaTimeWithCeaseFire = deltaTime;

        timeScale = UnityEngine.Time.timeScale;

        is_cease_fire_ = false;
    }
    void Update()
    {
        time = UnityEngine.Time.time;
        deltaTime = UnityEngine.Time.deltaTime;
        timeScale = UnityEngine.Time.timeScale;
        if (!is_cease_fire_)
        {
            timeWithCeaseFire = time;
            deltaTimeWithCeaseFire = deltaTime;
        }
        else
            deltaTimeWithCeaseFire = 0;
    }

    public static void ChangeCeaseFire() 
    {
        is_cease_fire_ = !is_cease_fire_;
    }
}
