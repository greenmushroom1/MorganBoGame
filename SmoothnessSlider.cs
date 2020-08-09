using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SmoothnessSlider : MonoBehaviour
{
    public InputField input;
    string previousValue;
    private void Start()
    {
        input.onEndEdit.AddListener(delegate { InputEdited(); });
    }

    public void SetValue(string v)
    {
        previousValue = v;
        input.text = v;
    }

    void InputEdited()
    {
        try
        {
            float.Parse(input.text);
        }
        catch (FormatException)
        {
            input.text = previousValue;
        }
        previousValue = input.text;
    }
}
