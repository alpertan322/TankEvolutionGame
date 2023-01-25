using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    
    
    // Helper Classes
    [SerializeField] private ParticleSystem[] confettis;
    private Rigidbody rg;
    private CharacterAnimController _characterAnimController;
    private GameStatus _gameStatus;


    // Movement
    [SerializeField] private float speed = 10;

    private bool atFloor;

    
    [SerializeField]  GameObject player;
    private bool isSwiping;

    private bool onFinish;
    private bool isStopped;
    private bool isWalking;

    private Vector3 totalDistanceWent;
    private Vector3 startingPos;
    private Vector3 currentPos;
    private void Awake()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
        _characterAnimController = FindObjectOfType<CharacterAnimController>();
    }

    void Start()
    {
        isWalking = false;
        onFinish = false;
        isStopped = false;
 
        
        atFloor = true;
        rg = gameObject.GetComponent<Rigidbody>();
        rg.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

        startingPos = transform.position;
        currentPos = transform.position;
    }

    private void FixedUpdate()
    {
        rg.angularVelocity = new Vector3(0, 0, 0);
        if (atFloor)
        {
            rg.velocity = new Vector3(0, 0, speed);
          
        }
        else
        {
            rg.velocity = new Vector3(0, 0, 0);
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        totalDistanceWent = currentPos - startingPos;

    }

    public float GetSpeed()
    {
        return speed;
    }

    public Vector3 GetTotalDistance()
    {
        return totalDistanceWent;
    }

    





public void SetOnFinish(bool f)
    {
        onFinish = f;
    }

     public ParticleSystem[] GetConfettis()
     {
         return confettis;
     }

 
     public void StartWalk()
     {
         isWalking = true;
       //  _characterAnimController.TriggerWalk();
       // tank animasyonu
     }

     public void SetSpeed(float s)
     {
         speed = s;
     }
}
