using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextValue : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _valueName;
    void Start()
    {
        _text = GetComponent<Text>();
    }
    public void UpdateText(decimal value)
    {
        _text.text = $"{_valueName}: {value}";
    }
}
