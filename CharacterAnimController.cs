using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerWalk()
    {
        _animator.SetTrigger("Walking");
        
        Debug.Log("Walking Triggered");
    }
    public void TriggerRun()
    {
        _animator.SetTrigger("Running");
    }
    
}
