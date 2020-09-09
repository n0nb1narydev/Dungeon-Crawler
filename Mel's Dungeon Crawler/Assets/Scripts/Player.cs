using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    private NavMeshAgent nma;
    private Animator anim;
    private bool isRunning = false;
    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                nma.destination = hit.point;
            }
        }

        if(nma.remainingDistance <= nma.stoppingDistance)
        {
            isRunning = false;
        } 
        else
        {
            isRunning = true;
        }

        anim.SetBool("isRunning", isRunning);
    }

}
