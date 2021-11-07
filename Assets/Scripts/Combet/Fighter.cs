using System;
using System.Collections;
using System.Collections.Generic;
using PRG.CombatTarget;
using UnityEngine;

namespace RPG.CombatFighter
{
    public class Fighter : MonoBehaviour
{
    public void Attack( CombatTarget target ){
        print("enemy is not attacking so attack ");
        Debug.Log("this is debug log");
    }
}
}
