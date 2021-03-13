using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text_;
    
    public void SetText(int number)
    {
        text_.text = number.ToString();
        Destroy(gameObject, 1);
    }
}
