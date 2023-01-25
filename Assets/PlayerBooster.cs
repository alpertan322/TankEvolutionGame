using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBooster : MonoBehaviour
{
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _player.SetSpeed(30);
        }
    }
}
