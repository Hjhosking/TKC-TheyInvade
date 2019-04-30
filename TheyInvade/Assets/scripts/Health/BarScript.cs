using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarScript : MonoBehaviour
{
    //Seralizefield makes visable in inspector but not accessible
   
    private float fillAmount;
    [SerializeField]
    private Image content;
    // Start is called before the first frame update
    [SerializeField]
    public float MaxValue { get; set; }
    [SerializeField]
    private float lerpSpeed;


    public float Value
    {
        set
        {
            fillAmount = Map(value, MaxValue);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        //Only update if current fill doesnt match display
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount,fillAmount,Time.deltaTime*lerpSpeed);
        }
    }

    //Translate health level to fill percentage 
    //value is current health
    private float Map(float value, float maxHealth)
    {
        return value / maxHealth;
    }
}
