using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;
using UnityEditorInternal;

public enum State
{
    WALK,
    ATTACK,
    DIE
}

public class Rake : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] GameObject destination;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        state = State.WALK;
        destination = GameObject.Find("Nexus");
    }

    void Update()
    {
        switch (state)
        {
            case State.WALK: Walk();
                break;
            case State.ATTACK: Attack(); 
                break;
            case State.DIE: Die(); 
                break;

        }
    }

    void Walk()
    {
        navMeshAgent.SetDestination(destination.transform.position);

        transform.LookAt(destination.transform.position);
    }

    void Attack()
    {
        animator.Play("Attack");
    }


    public void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nexus"))
        {
            state = State.ATTACK;
        }
    }
}
