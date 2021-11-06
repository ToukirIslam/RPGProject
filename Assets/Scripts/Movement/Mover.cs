using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        if (Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
    }
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hashit = Physics.Raycast(ray, out hit);
        if (hashit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
    private void UpdateAnimator()
    {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); //use it to make it local velocity 
        float speed = localVelocity.z;
        character.SetFloat("ForwardSpeed", speed);
    }
    
}