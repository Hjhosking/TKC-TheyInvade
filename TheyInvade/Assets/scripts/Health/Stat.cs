using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat 
{
    [SerializeField]
    private BarScript bar;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }
        set
        {
            //set the current value
            this.currentVal = Mathf.Clamp(value,0,MaxVal); 
            //update the bar
            bar.Value = currentVal;
        }
    }

    public float MaxVal {
        get {
            return maxVal; }
        set {
            this.maxVal = value;
            //sets the bars maximum value, having flexible max
            //is dynamic eg for shields or increased health
           bar.MaxValue = maxVal;
        }
    }

    //set the maxvalue and current values to the bar
    public void Initialize()
    {
        this.MaxVal = 3;
        this.CurrentVal = 3;
    }
}
