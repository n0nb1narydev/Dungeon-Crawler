using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
    private NavMeshAgent nma;
    private Animator anim;
    private bool isRunning = false;
    private bool isFighting = false;
    public bool isDead = false;
    public int Experience = 0;
    private Skeleton skeleton;
    public double level = 1;
    public int lives = 29;
    public bool coroutineStartedFlag = false;
    private UI_Manager uiManager;
    [SerializeField]
    private Transform startPos;
    private bool isIdle = false;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skeleton = GameObject.Find("Skeleton").GetComponent<Skeleton>();
        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100) && isDead == false)
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
        anim.SetBool("isIdle", isIdle);
        anim.SetBool("isDead", isDead);
    }
    public IEnumerator DamagePlayer(int min, int max)
    {   
            coroutineStartedFlag = true;
            yield return new WaitForSeconds(.5f);
            int hitForRandom = Random.Range(min, max);
            lives -= hitForRandom;
            uiManager.UpdateLives(lives);
            if(lives < 1)
            {
                isDead = true;
                isRunning = false;
                StartCoroutine(PlayerDeath());
            }
            Debug.Log(hitForRandom);
            yield return new WaitForSeconds(1.5f);
            coroutineStartedFlag = false;
    }
    private IEnumerator PlayerDeath()
    {
        yield return new WaitForSeconds(4);
        Respawn();

    }
    private void Respawn()
    {
        transform.position = startPos.transform.position;
        transform.rotation = startPos.transform.rotation;
        isDead = false;
        isIdle = true;
        lives = 29;
        uiManager.UpdateLives(lives);
        nma.destination = transform.position;
    }
}
