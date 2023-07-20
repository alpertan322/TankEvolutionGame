using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private float patrolDuration;
    private float patrolTimeStamp;

    [SerializeField] private float patrolRange;
    private float curPatrolRange;
    private Vector3 patrolVec;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
       startPos = gameObject.transform.position; 
       patrolVec = new Vector3(patrolRange, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        if (patrolTimeStamp > patrolDuration)
        {

             curPatrolRange = Random.Range(0, patrolRange);
             patrolVec = new Vector3(curPatrolRange, 0, 0);
        }
        patrolTimeStamp = patrolTimeStamp + Time.deltaTime;
    }

    private void Patrol() {
       gameObject.transform.position = Vector3.Lerp(startPos, startPos + patrolVec, patrolTimeStamp / patrolDuration); 
    }
}
