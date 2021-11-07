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
            InteractWithConbat();
            InteractWithMovement();
        }

        private void InteractWithConbat()
        {
          RaycastHit[] hits =  Physics.RaycastAll(GetMouseRay());
          foreach (RaycastHit hit in hits)
          {
             CombatTarget target=  hit.transform.GetComponent<CombatTarget>();
             if(target == null){continue;}
             if(Input.GetMouseButtonDown(0)){
                 GetComponent<Fighter>().Attack(target);
             }
          }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hit;
            bool hashit = Physics.Raycast(GetMouseRay(), out hit);
            if (hashit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
 }
