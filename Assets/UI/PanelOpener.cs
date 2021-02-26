using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup panel_;
    [SerializeField]
    private Type type_;

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        bool open = true;
        switch (type_)
        {
            case Type.Close:open = false;break;
            case Type.Toggle:
                {
                    open = !panel_.interactable;
                    break;
                }
        }
        panel_.alpha = open ? 1 : 0;
        panel_.interactable = open;
        panel_.blocksRaycasts = open;
    }
    private enum Type { Open, Close, Toggle }
}
