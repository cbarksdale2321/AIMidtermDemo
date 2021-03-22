using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : EnemyBaseClass, IEnemy
{
    // Start is called before the first frame update
    void Start()
    {
        this.currentState = EnemyStates.SearchforClosestEnemy;
        damageMin = 2;
        damageMax = 8;
        health = 15;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyStates.Spawned:

                break;
            case EnemyStates.SearchforClosestEnemy:
                FindClosestPlayer();
                break;
            case EnemyStates.SearchforClosestBuilding:
                SearchforBuilding();
                break;
            case EnemyStates.Attack:
                Attack();
                break;
            case EnemyStates.Defend:
                DefendBuilding();
                break;

        }
    }
 
}
