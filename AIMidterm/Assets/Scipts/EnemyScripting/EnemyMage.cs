using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMage : EnemyBaseClass, IEnemy
{
    ProjectileScript projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<ProjectileScript>();

        this.currentState = EnemyStates.SearchforClosestEnemy;
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
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Warrior" || collision.gameObject.tag == "Mage" || collision.gameObject.tag == "Archer")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Building")
        {
            Destroy(this.gameObject);
        }
    }


}
