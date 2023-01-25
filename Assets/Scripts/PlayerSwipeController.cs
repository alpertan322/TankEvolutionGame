using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSwipeController : MonoBehaviour
{
  

    private float maxSensitive = 2000;
    [Range(1, 10)] [SerializeField] private float sensitivityX;
    private float constantOfMoveX;
  [SerializeField] float currentInterpolationX = 0.5f;

  
  [SerializeField] float interpolationX = 0.5f;

  [Header("Boundaries")] 
  // Tank 1 Boundaries
  [SerializeField] private Transform leftMost1;
  [SerializeField] private Transform rightMost1;
  // Tank 2 Boundaries
  [SerializeField] private Transform leftMost2;
  [SerializeField] private Transform rightMost2;
  // Tank 3 Boundaries
  [SerializeField] private Transform leftMost3;
  [SerializeField] private Transform rightMost3;
  // Tank 4 Boundaries
  [SerializeField] private Transform leftMost4;
  [SerializeField] private Transform rightMost4;
  // Tank 5 Boundaries
  [SerializeField] private Transform leftMost5;
  [SerializeField] private Transform rightMost5;
  // Tank 6 Boundaries
  [SerializeField] private Transform leftMost6;
  [SerializeField] private Transform rightMost6;
  
  private Transform currentLeft;
  private Transform currentRight;
  
    // starting
    float startingScreenPosX;

    // current
    float currentScreenPosX;



    private float deltaPosX;


    private Vector3 screenSwipeVector;
    void Start()
    {
        Time.timeScale = 0;
      
        constantOfMoveX = maxSensitive - ((sensitivityX * maxSensitive) / 10);
       
        SetCurrentBoundaries(1);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            {
                startingScreenPosX = finger.position.x;
               
             
             
             
            }

            if (finger.phase == TouchPhase.Moved)
            {


                currentScreenPosX = finger.position.x;
       

                deltaPosX = currentScreenPosX - startingScreenPosX;
          


                currentInterpolationX = Mathf.Clamp(interpolationX + (deltaPosX / constantOfMoveX), 0, 1);

                SetUpBoundariesAndMove();
              
                

            }

            if (finger.phase == TouchPhase.Ended)
            {

                interpolationX = currentInterpolationX;

            }


        }

        if (Input.GetMouseButtonDown(0))
        {
            startingScreenPosX = Input.mousePosition.x;

        }

        if (Input.GetMouseButton(0))
        {
            currentScreenPosX = Input.mousePosition.x;
       

            deltaPosX = currentScreenPosX - startingScreenPosX;
          


            currentInterpolationX = Mathf.Clamp(interpolationX + (deltaPosX / constantOfMoveX), 0, 1);

            SetUpBoundariesAndMove();

        }

        if (Input.GetMouseButtonUp(0))
        {
            interpolationX = currentInterpolationX;
        }
    }


    
     void SetUpBoundariesAndMove()
    {
        Vector3 curX = Vector3.Lerp(currentLeft.position, currentRight.position, currentInterpolationX);
        transform.position = new Vector3(curX.x , transform.position.y,transform.position.z);



    }


     public void SetCurrentBoundaries(int level)
     {
         if (level == 1)
         {
             currentLeft = leftMost1;
             currentRight = rightMost1;
         }
         else if (level == 2)
         {
             currentLeft = leftMost2;
             currentRight = rightMost2;
         }
         else if (level == 3)
         {
             currentLeft = leftMost3;
             currentRight = rightMost3;
         }
         else if (level == 4)
         {
             currentLeft = leftMost4;
             currentRight = rightMost4;
         }
         else if (level == 5)
         {
             currentLeft = leftMost5;
             currentRight = rightMost5;
         }
         else if (level == 6)
         {
             currentLeft = leftMost6;
             currentRight = rightMost6;
         }
     }
  
     
    
}
