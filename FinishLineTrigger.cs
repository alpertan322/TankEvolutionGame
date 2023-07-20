using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    private GameStatus _gameStatus;
    [SerializeField] private GameObject particle;
    private Player _player;
    private ShooterController _shooterController;
    private SoundManager _soundManager;
    private void Awake()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
        _player = FindObjectOfType<Player>();
        _shooterController = FindObjectOfType<ShooterController>();
        _soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("sadf");
        if (other.tag  == "Player")
        {
              particle.SetActive(true);
            StartCoroutine(Wait());
        }
    }
    
    

    IEnumerator Wait()
    {
        _shooterController.SetGameOver();
        _player.SetSpeed(0);
        _soundManager.PlayWinSound();
        yield return new WaitForSecondsRealtime(2.5f);
        _gameStatus.Win();
    }
}