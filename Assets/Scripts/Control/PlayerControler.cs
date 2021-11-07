using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using RPG.Movement;
using PRG.CombatTarget;
using RPG.CombatFighter;

namespace RPG.Control
 {
public class PlayerControler : MonoBehaviour
{
    private void Update()
        {
            if( InteractWithConbat()){return;}
           if(  InteractWithMovement()){return;} //("no place to go ") implimentation , make thing into bool 
        }

        private bool InteractWithConbat()
        {
          RaycastHit[] hits =  Physics.RaycastAll(GetMouseRay());
          foreach (RaycastHit hit in hits)
          {
             CombatTarget target=  hit.transform.GetComponent<CombatTarget>();
             if(target == null){continue;}
             if(Input.GetMouseButtonDown(0)){
                 GetComponent<Fighter>().Attack(target);
             }
             return true;
          }
          return false;
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit )
            {
                if(Input.GetMouseButton(0)){
                GetComponent<Mover>().MoveTo(hit.point);

                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
 }
