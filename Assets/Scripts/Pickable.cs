using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
  private TankController _tankController;


  private void Awake()
  {
    _tankController = FindObjectOfType<TankController>();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Player")
    {
      gameObject.SetActive(false);
      _tankController.ShooterAmountUp();
    }
  }

 
}
