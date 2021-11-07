using System;
using System.Collections;
using System.Collections.Generic;
using PRG.CombatTarget;
using UnityEngine;
using RPG.Movement;
namespace RPG.CombatFighter
{
    public class Fighter : MonoBehaviour
{
    [SerializeField] float WeaponRange = 2;
    Transform target;
    private void Update()
    {
        bool isInRange = Vector3.Distance(transform.position,target.position)<WeaponRange ;
        if(target != null && !isInRange){
            GetComponent<Mover>().MoveTo(target.position);
        }
        else{
             GetComponent<Mover>().Stop();
        }
    }
    public void Attack( CombatTarget combarTarget )
    {
        target = combarTarget.transform;    
    }
}
}
