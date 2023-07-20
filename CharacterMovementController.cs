using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private GameObject character;
    
    
    private CharacterAnimController _characterAnimController;

    [SerializeField] float speedFactorWalking = 1;
    [SerializeField] float speedFactorRunning = 1;
    
    
    private bool isRunning;
    private bool isWalking;


    private Vector3 characterRightVector3;
    private Vector3 characterLeftVector3;
    
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;

    private float beginningX;
    private float currentX;

    private float diffX;

    private Camera main;
    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _characterAnimController = GetComponent<CharacterAnimController>();
    }

    private void Start()
    {
        main = Camera.main;
        
    }

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {                                       
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            { 
                beginningX = finger.position.x;
              

            }
            if (finger.phase == TouchPhase.Moved)
            {
                currentX = finger.position.x;
                diffX = currentX - beginningX;
                Vector3 position = new Vector3(Input.mousePosition.x,Camera.main.WorldToScreenPoint(character.transform.position).y, Camera.main.WorldToScreenPoint(character.transform.position).z);
                character.transform.position = position;
                if (diffX >= 0)
                {
                    // move right
                    Debug.Log("R");
               
                }
                else
                {
                    // move left
                    Debug.Log("L");
                }

            }
            if (finger.phase == TouchPhase.Ended)
            {
                diffX = 0;
                beginningX = 0;
                currentX = 0;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            characterRightVector3 = transform.right;
            characterLeftVector3 = -transform.right;
            
            _rigidbody.velocity = Vector3.forward * Time.deltaTime * speedFactorRunning;
        }
        else if (isWalking)
        {
            characterRightVector3 = transform.right;
            characterLeftVector3 = -transform.right;
            
            _rigidbody.velocity = Vector3.forward * Time.deltaTime * speedFactorWalking;
        }
        
    }

    public void StartWalking()
    {
        _characterAnimController.TriggerWalk();
        isWalking = true;
    }
    public void StartRunning()
    {
        _characterAnimController.TriggerRun();
        isRunning = true;
    }
    
    
}
