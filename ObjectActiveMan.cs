using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveMan : MonoBehaviour
{
   [SerializeField] private float range;
   [SerializeField] private LayerMask player;
   [SerializeField] GameObject obj;
   private bool isInRange;
   private bool isActivated;

   private void Start()
   {
      isInRange = false;
      isActivated = false;
   }

   private void FixedUpdate()
   {
       isInRange = Physics.CheckSphere(transform.position, range, player);

       if (!isActivated)
       {
           if (isInRange)
           {
               isActivated = true;
               obj.SetActive(true);
           }
       }
     
  
   }
}
