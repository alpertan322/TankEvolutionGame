using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateCollisionController : MonoBehaviour
{
 
    
    private void OnTriggerEnter(Collider collision) 
    {
         
            if (gameObject.tag == "AmountUp" && collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<TankController>().ShooterAmountUp();
               
               
             
            }
            else if (gameObject.tag == "SpeedUp" && collision.gameObject.tag == "Player" )
            {
                collision.gameObject.GetComponent<TankController>().ShooterSpeedUp();
            
    
            }
            else if (gameObject.tag == "SpeedDown" && collision.gameObject.tag == "Player" )
            {
                collision.gameObject.GetComponent<TankController>().ShooterSpeedDown();
              
    
            }
            else if (gameObject.tag == "DoubleAmmo" && collision.gameObject.tag == "Player" )
            {
                collision.gameObject.GetComponent<TankController>().SetAmmoLevel(2);
               
    
            }  
            else if (gameObject.tag == "TripleAmmo" && collision.gameObject.tag == "Player" )
            {
                collision.gameObject.GetComponent<TankController>().SetAmmoLevel(3);
          
    
            }
            else if (gameObject.tag == "QuadraAmmo" && collision.gameObject.tag == "Player" )
            {
                collision.gameObject.GetComponent<TankController>().SetAmmoLevel(4);
              
            }

         
      
    }

 
}
