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
            isWalking = true;
            isFighting = false;
            _nma.SetDestination(player.transform.position);
        } 
        if(dist <= minDist) //combat range
        {
            isWalking = false;
            isFighting = true;
        }
        if(this.isFighting == true && this.tag == "level1")
        {
            StartCoroutine(HitPlayer());
        }
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isFighting", isFighting);
    }
    IEnumerator HitPlayer()
    {
        yield return new WaitForSeconds(3f);
        player.DamagePlayer(1, 5);
    }
}
