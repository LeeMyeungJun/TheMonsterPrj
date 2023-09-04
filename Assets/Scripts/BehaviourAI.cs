using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[Serializable]
public struct AnimData
{
    public string triggerName;
    public string animStateName;
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class BehaviourAI : MonoBehaviour
{
    protected AnimData curAnimData;

    [SerializeField]
    protected List<AnimData> atkAnimDatas = new List<AnimData>();

    [SerializeField]
    protected List<AnimData> rangeAnimDatas = new List<AnimData>();

    [Header("Range")]
    [SerializeField]
    protected float _detectRange = 10f;
    [SerializeField]
    protected float _meleeAttackRange = 5f;
    [SerializeField]
    protected float _rangeAttackRange = 10f;

    [Header("Movement")]
    [SerializeField]
    float _movementSpeed = 10f;

    protected bool isWait = false;
    protected float elapsedTime = 0.0f;
    protected float waitTime;
    protected EnvironmentQuery.EQSData eqs;
    protected NavMeshAgent agent;

    protected BehaviorTree _BTRunner = null;
    protected Animator _animator = null;


   
    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = _movementSpeed;
        
    }



    protected virtual void Update()
    {
        if (isWait)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= waitTime)
            {
                isWait = false;
                elapsedTime = 0.0f;
                waitTime = 0.0f;
            }
        }
        else
        {
            _BTRunner.Run();
        }

        _animator.SetFloat("fSpeed", agent.velocity.sqrMagnitude);
    }


    protected bool IsAnimationRunning(string stateName)
    {
        if (_animator != null)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
            {
                var normalizedTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;

                return normalizedTime != 0 && normalizedTime < 1f;
            }
        }

        return false;
    }


    protected void SetWaitTime(float _time)
    {
        isWait = true;
        waitTime = _time;
    }
   

  
}
