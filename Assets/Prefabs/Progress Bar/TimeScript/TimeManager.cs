using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Slider remainingTimeProgressBar;
    [SerializeField] private float totalTime;
    private float remainingTime;
    private float passedTime;

    private float interpolatedAmountOfRemainingTime;
    [SerializeField] private bool isKeepingTime;

    private void Start()
    {
        isKeepingTime = false;
       
    }

    private void Update()
    {
        if (isKeepingTime)
        {
            passedTime += Time.deltaTime;
            remainingTime = totalTime - passedTime;
            interpolatedAmountOfRemainingTime = remainingTime / totalTime;
            
            UpdateTimeProgressBar(interpolatedAmountOfRemainingTime);
            
            
        }
     
    }

    public void  StartGameTimer()
    { 
        passedTime = 0;
        isKeepingTime = true;
    }

    private void UpdateTimeProgressBar( float remainingTime)
    {
        remainingTimeProgressBar.value = remainingTime;
    }
}
