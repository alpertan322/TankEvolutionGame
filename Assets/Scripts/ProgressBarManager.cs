using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{
    [SerializeField] private Slider[] progressBarSliders;
    [SerializeField] private GameObject[] progressBars;
    [SerializeField] private TextMeshPro[] progressBarsTMPs;
    [SerializeField] private Slider specialCaseSlider;
    [SerializeField] private GameObject specialCase;
    [SerializeField] private TextMeshPro specialCaseTMP;
    private Slider currentProgressBarSlider;
    private GameObject currentProgressBar;
    private ProgressBar _progressBar;

    private void Awake()
    {
        _progressBar = FindObjectOfType<ProgressBar>();
        
    }

    private void Start()
    {
      AssignCurrentProgressBar(1,1);
      
    }



    public void AssignCurrentProgressBar(int tankLevel , int ammoLevel)
    {
        if (currentProgressBar != null)
        {
            currentProgressBar.SetActive(false);
        }
        if (ammoLevel >= 3 && tankLevel == 2)
        { 
          
            currentProgressBar = specialCase;
            currentProgressBarSlider = specialCaseSlider;
            specialCaseTMP.SetText("Level "+ tankLevel);
        }
        else
        {
            if (tankLevel <= 5)
            {
                currentProgressBar = progressBars[tankLevel - 1];
                currentProgressBarSlider = progressBarSliders[tankLevel - 1];
                progressBarsTMPs[tankLevel-1].SetText("Level "+ tankLevel);
            }
        
        }
        currentProgressBar.SetActive(false);
        _progressBar.AssignCurrentProgressBar(currentProgressBarSlider, currentProgressBar);
       
        
       
    }
}
