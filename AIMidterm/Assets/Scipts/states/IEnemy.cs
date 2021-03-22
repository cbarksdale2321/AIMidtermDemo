using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void Attack();
    void DefendBuilding();
    void Run();
   // void SearchForEnemy();
    void SearchforBuilding();
    
    

   
}
public enum EnemyStates
{
    Spawned,
    SearchforClosestEnemy,
    SearchforClosestBuilding,
    Attack,
    Defend,
    Taunt,
    Dead
}

