using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    public bool isFighting = false;
    private bool isWalking = false;
    private Animator animator;
    private Player player;
    private NavMeshAgent _nma;
    private float minDist=1f;
    private float maxDist= 3.5f;
    [SerializeField]
    private float dist;
    private IEnumerator level1Dmg;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _nma = this.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <= maxDist) //aggro range
        {
            if(player.isDead == false)
            {
                isWalking = true;
                isFighting = false;
                _nma.SetDestination(player.transform.position);
            }
        } 
        if(dist <= minDist) //combat range
        {
            if(player.isDead == false)
            {
                isWalking = false;
                isFighting = true;
            }
        }
        if(player.isDead == true)
        {
            isFighting = false;
            isWalking = false;
        }
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isFighting", isFighting);
    }
    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        level1Dmg = player.DamagePlayer(0, 5);
        if(this.isFighting == true && this.tag == "level1" && player.coroutineStartedFlag == false)
        {
            StartCoroutine(level1Dmg);
        }
    }
}
