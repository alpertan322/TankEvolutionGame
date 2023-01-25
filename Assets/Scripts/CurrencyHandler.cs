using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/*
 * Created by Kutay Senyigit for Trelans Studio
 * Date: 14/06/2022
 * 
 */
public class CurrencyHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyTMP;
    
    private int currentScore;
    private PlayerProgression _playerProgression;


    private void Awake()
    {
      
        _playerProgression = FindObjectOfType<PlayerProgression>();
    }

    private void Start()
    {
        OnStart();
    }
    
    /*
     * Gets an int and adds it into your currentScore
     */
    
    public void IncreaseCurrency(int amount)
    {
        currentScore += amount;
        UpdateScore();
        
    }
    
    /*
     * Gets an int and sets it as your currentScore
     */
    
    public void SetCurrency(int amount)
    {
        currentScore = amount;
        UpdateScore();

    }

    /*
     * Sets TMP as currentScore's values
     */
    
    private void UpdateScore()
    {
        currencyTMP.SetText(currentScore + "");
        _playerProgression.SaveCurrency(currentScore);
        
    }

    /*
     * Gets initial value of currency
     *
     */
    private void OnStart()
    {
       currentScore =  _playerProgression.GetCurrency();
       UpdateScore();
    }
}
