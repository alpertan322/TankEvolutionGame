using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private int MAX = 20;
    private int current;
    private float currentSliderValue;
    private TankController _tankController;

    private GameObject child;

    private bool isFired;
    private ProgressBarManager _progressBarManager;

    private int currentTankLevel;
    private int currentLevelIndex;

    private int[] tankLevelEasy =
    {
        50, 40, 30, 20 ,10 };

    private bool isProgressDone;
    private int count;
    private void Awake()
    {
        _tankController = FindObjectOfType<TankController>();
        _progressBarManager = FindObjectOfType<ProgressBarManager>();
    }

    private void Start()
    {
        current = 0;
        count = 0;
        _slider.value = 0;
        isFired = false;
        currentTankLevel = 1;
        currentLevelIndex = PlayerPrefs.GetInt("levelIndex", 0);
        isProgressDone = false;
    }

    private void HandleTankLevelDifficulty()
    {
        int diffFactor;
        int diff = currentLevelIndex + 1 - currentTankLevel;
        if (diff >= 0)
        {
           diffFactor  = 50 - (diff * 10);
        }
        else
        {
            diffFactor = 50;
        }
      
        
    }
    public void IncreaseSlider()
    {
        
       
        if (currentTankLevel < 6 && !isProgressDone)
        {
            StartCoroutine(WaitToClosePanel()); 
            if (MAX > current)
            {
                current++;
           
                if (MAX == current)
                {
                    _tankController.TankLevelUp();
                    current = 0;
                    count++;
                    if (count == 5)
                    {
                        isProgressDone = true;
                    }
                }
                currentSliderValue = (float) current / MAX;
                _slider.value = currentSliderValue;
            }
        }
     
        
        
   
    }

    IEnumerator WaitToClosePanel()
    {
        child.SetActive(true);
        isFired = true;
        
        yield return new WaitForSeconds(5f);
        
        if (!isFired)
        {
            child.SetActive(false);
            isFired = false;
        }
 
    }

    public void AssignCurrentProgressBar( Slider c , GameObject g)
    {
        isFired = false;
        child = g;
        Slider cu = c;
        cu.value = _slider.value;
        _slider = cu;
        child.SetActive(false);
    }

    public void IncreaseCurrentTankLevel()
    {
        currentTankLevel++;
    }
}
