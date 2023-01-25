using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlower : MonoBehaviour
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
            _player.SetSpeed(1f);
         //  Time.timeScale = 0.1f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          //  Time.timeScale = 1;
          _player.SetSpeed(10f);
        }
    }
}
