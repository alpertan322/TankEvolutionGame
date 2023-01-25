using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLineController : MonoBehaviour
{
    [SerializeField] private EnemyGeneratorController _enemyGeneratorController;
    
    private List<Enemy> lastLine;
    
    private void Awake()
    {
    
    }
}
