using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingLineTrigger : MonoBehaviour
{
    private Player _player;

    private bool isWaiting;

    private void Start()
    {
        isWaiting = false;
    }

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.tag  == "Player" && !isWaiting)
        {
            
            _player.SetSpeed(0);
            isWaiting = true;
     
        }
    }


    public void DontWait()
    {
        _player.SetSpeed(15);
    }
}