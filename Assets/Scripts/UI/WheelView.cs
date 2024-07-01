using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelView : MonoBehaviour
{
    [SerializeField] private Text[] roulettePrizLables; //dont create zone generation

    public void SetValues(string[] values)
    {
        try
        {
            for (var i = 0; i < roulettePrizLables.Length; i++) roulettePrizLables[i].text = values[i].ToString();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
