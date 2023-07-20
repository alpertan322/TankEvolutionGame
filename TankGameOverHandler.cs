using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGameOverHandler : MonoBehaviour
{
    private GameStatus _gameStatus;

    private void Awake()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") ||  other.gameObject.layer == LayerMask.NameToLayer("Block") )
        {
            Debug.Log("Game Over");
            _gameStatus.SetGameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer ==  LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Game Over");
            _gameStatus.SetGameOver();
        }
    }
}
