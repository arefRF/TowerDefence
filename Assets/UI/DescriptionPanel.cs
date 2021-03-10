using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField]
    private RectTransform rect_;
    [SerializeField]
    private CanvasGroup cg_;
    [SerializeField]
    private TextMeshProUGUI tilte_, description_;
    [SerializeField]
    private Vector2 offset_;

    private Vector2 min_pos_, max_pos_;
    private float size_scale_;
    private void Awake()
    {
        HidePanel();
    }
    private void Start()
    {
        SetBounds();
    }

    public void ShowPanel(string title, string description)
    {
        tilte_.text = title;
        description_.text = description;
        enabled = true;
        cg_.alpha = 1;
        SetBounds();
        UpdatePositon();
    }

    public void HidePanel()
    {
        enabled = false;
        cg_.alpha = 0;
    }

    private void Update()
    {
        UpdatePositon();
    }

    private void UpdatePositon()
    {
        var pos = (Vector2)Input.mousePosition + offset_ * size_scale_;
        pos.x = Mathf.Clamp(pos.x, min_pos_.x, max_pos_.x);
        pos.y = Mathf.Clamp(pos.y, min_pos_.y, max_pos_.y);
        rect_.position = pos;
    }
    private void SetBounds()
    {
        size_scale_ = UIManager.sSingleton.GetCanvasScale();
        min_pos_ = Vector2.zero;
        min_pos_.x = (rect_.sizeDelta.x / 2) * size_scale_;
        max_pos_.x = Screen.width - (rect_.sizeDelta.x / 2 * size_scale_);
        max_pos_.y = Screen.height - (rect_.sizeDelta.y * size_scale_);
    }
}
