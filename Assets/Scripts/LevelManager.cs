using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Created by Kutay Senyigit for Trelans Studio
 * Date: 14/06/2022
 * 
 */
public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    
    private int level;
    private int levelIndex;

    private int totalLevelCount;
    
    private PlayerProgression _playerProgression;

    private void Awake()
    {
        _playerProgression = FindObjectOfType<PlayerProgression>();
        
        
    }

    private void Start()
    {
        totalLevelCount = levels.Length;
    }

    public void LoadInitialLevel()
    {
        level =  _playerProgression.GetLevel();
        levelIndex =   _playerProgression.GetLevelIndex();
        LoadLevel(levelIndex);
        
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public void LoadNextLevel()
    {
        level++;
        levelIndex++;

        if (levelIndex == totalLevelCount)
        {
            levelIndex = 0;
        }

        SaveLevel();
        
        LoadLevel(levelIndex);
        
    }

    private void SaveLevel()
    {
        _playerProgression.SaveLevel(level);
        _playerProgression.SaveLevelIndex(levelIndex);
    }

    private void LoadLevel(int index)
    {
        levels[index].SetActive(true);
    }
}
