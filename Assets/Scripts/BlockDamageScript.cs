using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockDamageScript : MonoBehaviour
{
   [SerializeField] private TextMeshPro damageTMP;
   [SerializeField] private int health;

   [SerializeField] private GameObject mesh;
   [SerializeField] private ParticleSystem _particleSystem;
   private GameStatus _gameStatus;
   private BoxCollider boxCollider;
   private void Awake()
   {
      _gameStatus = FindObjectOfType<GameStatus>();
      boxCollider =  GetComponent<BoxCollider>();
   }

   private void Start()
   {
      damageTMP.SetText(health.ToString());

   }

   private void OnTriggerEnter(Collider other)
   {
    
      if (other.gameObject.tag == "Player")
      {
         _gameStatus.SetGameOver(); 
         Debug.Log("Game Over");
      }

      if (other.gameObject.tag == "Ammo" )
      {
         other.gameObject.SetActive(false);
         health--;
         if ( _particleSystem != null )
         {
            _particleSystem.Play();
         }
         StartCoroutine(HandleSize());
         if (health <= 0)
         {
            health = 0;
            if (health <= 0)
            {
               health = 0;
            
            }

            mesh.SetActive(false);
            boxCollider.enabled = false;
         }
         damageTMP.SetText(health.ToString());
     
      }
      
   }
   
   IEnumerator HandleSize()
   {
      transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
      yield return new WaitForSeconds(0.1f);
      transform.localScale = new Vector3(1, 1, 1);
   }
}
