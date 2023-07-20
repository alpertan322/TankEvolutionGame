using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.UIElements;
using UnityEngine;

public class ShooterRecoil : MonoBehaviour
{
    [SerializeField] private GameObject[] recoilObjectsA; // 
   
    private Vector3[] startingPos;
  
    [SerializeField] private float recoilDistanceA;

    [SerializeField] private float  recoilSpeed;
    [SerializeField] private float  recoilSpeedConstant;
    private float interpolationAmount;
    
    private bool isRecoiling ;

    private bool isGoingBack;
    private Player _player;


    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Start()
    {
        interpolationAmount = 0;
        isGoingBack = true;
        CalculateStartingAndEndPos();
        
      
    }

    private void FixedUpdate()
    {
        if (isRecoiling)
        {
            
            for (int i = 0; i < recoilObjectsA.Length; i++)
            {
            
              PerformRecoilA(   recoilObjectsA[i]  );
          
            }
          
          
        }    
    }

   
    private void CalculateStartingAndEndPos()
    {
        int sizeA = recoilObjectsA.Length;

        startingPos = new Vector3[sizeA];
      

        for (int i = 0; i < sizeA; i++)
        {
            Vector3 s = new Vector3(recoilObjectsA[i].transform.position.x , recoilObjectsA[i].transform.position.y , recoilObjectsA[i].transform.position.z);
            startingPos[i] = s;
        }
    
        
        
    }

  
    private void CalculateInterpolation()
    {
        if (isGoingBack)
        {
            if (interpolationAmount >= 0 && interpolationAmount < 1 )
            {
                interpolationAmount += Time.deltaTime * recoilSpeed * recoilSpeedConstant;
            }

            if (interpolationAmount >= 1 )
            {
                interpolationAmount = 1;
                isGoingBack = false;
            }
        }
        else
        {
            if (interpolationAmount >= 0 && interpolationAmount <= 1 )
            {
                interpolationAmount -= Time.deltaTime * recoilSpeed * recoilSpeedConstant;
            }

            if (interpolationAmount <= 0 )
            {
                interpolationAmount = 0;
                isGoingBack = true;
            }
        }   


    }
    private void PerformRecoilA(GameObject gameObject )
    {
        CalculateInterpolation();
        for (int i = 0; i < recoilObjectsA.Length; i++)
        {
            Vector3 s = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y,startingPos[i].z + _player.GetTotalDistance().z -0.3f );
            Vector3 e = new Vector3(gameObject.transform.position.x , gameObject.transform.position.y , recoilObjectsA[i].transform.position.z);
            e = s + Vector3.forward * -recoilDistanceA;
            gameObject.transform.position = Vector3.Lerp(e, s, interpolationAmount);
        }
   
    }



    public void SetRecoil(bool r)
    {

        isRecoiling = r;
    }
}
