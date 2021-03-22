using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SiegeWeapon : EnemyBaseClass
{
    // Start is called before the first frame update
    GameObject[] allBuildings;
    void Start()
    {
        allBuildings = GameObject.FindGameObjectsWithTag("Building");
        this.currentState = EnemyStates.SearchforClosestBuilding;
        this.gameObject.tag = "SiegeWeapon";
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

    private void OnCollisionEnter(Collision collision)
    {
        
      
        if (collision.gameObject.tag == "Warrior" || collision.gameObject.tag == "Mage" || collision.gameObject.tag == "Archer" ) 
        {
            health = health--;
        }
        if (collision.gameObject.tag == "Building")
        {
            Destroy(this.gameObject);
        }
    }

    public override void SearchforBuilding()
    {
        base.SearchforBuilding();
        GameObject furthest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject building in allBuildings)
        {
            Vector3 diff = building.transform.position - position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                furthest = building;
                distance = curDistance;
            }
            this.GetComponent<NavMeshAgent>().SetDestination(furthest.transform.position);
        }
    }
}
