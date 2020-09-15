using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Door : MonoBehaviour
{
    private Animator animator;
    private Player player;
    private bool isOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player" && player.level == 1)
        {
            isOpen = true;
            animator.SetBool("isOpen", isOpen);
        }
    }
}    

