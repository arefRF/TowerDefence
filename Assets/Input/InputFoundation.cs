using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFoundation : MonoBehaviour
{
    public static InputFoundation sSingleton;
    // Start is called before the first frame update
    void Start()
    {
        sSingleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.sSingleton.LeftMouseClicked();
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.sSingleton.RightMouseClicked();
        }

        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            GameManager.sSingleton.TabPressed();
        }

        if (Input.GetMouseButtonUp(0))
        {
            UIManager.sSingleton.PointerUp();
        }
    }
}
