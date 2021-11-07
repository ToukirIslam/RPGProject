using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement
{
public class Mover : MonoBehaviour
{
    NavMeshAgent agent;
    Animator character;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Animator>();
        
    }
    void Update()
    {
        UpdateAnimator();
    } 

    public void MoveTo(Vector3 destination) 
    {
        GetComponent<NavMeshAgent>().destination = destination;
        agent.isStopped = false;
    }
    public void Stop(){
        agent.isStopped = true;
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); //use it to make it local velocity 
        float speed = localVelocity.z;
        character.SetFloat("ForwardSpeed", speed);
    }
    
}
}
