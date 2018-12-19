using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;

    private NavMeshAgent agent;
    private Animator animator;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
        if (agent.remainingDistance == 0)
        {
            animator.Play("HumanoidIdle");
        }
        else
        {
            IsShow();
        }


    }

    void IsShow()
    {
        playerAnimator.SetBool("HumanoidRun", true);

    }
}
