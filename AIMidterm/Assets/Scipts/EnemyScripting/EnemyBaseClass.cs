using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBaseClass : MonoBehaviour, IEnemy
{
    //different weighted behaviours for different enemy types
    //world state machine
    //seige weapon that only cares for buildings
    //raycasting (sphere,box)
    //player base class
    //rock/paper/scissors
    public EnemyStates currentState = EnemyStates.SearchforClosestEnemy;
    private float distanceBetweenClosestPlayer;
    Vector3 tempPos;

    //design variables
    bool canSeePlayer;
    bool canSeeBuilding;
    [SerializeField] public float lookDistance;
    [SerializeField] public float attackDistance;
    [SerializeField] public int health;
    [SerializeField] public int damageMin;
    [SerializeField] public int damageMax;
    public static int damage;

    void Start()
    {
        tempPos = RandomNavmeshLocation(15);


    }
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
   

    public virtual void Attack()
    {
        if (health >= 5)
        {
            this.FindClosestPlayer();
            damage = Random.Range(damageMin, damageMax);
            Debug.Log("Damaging for " + damage + " damage");
        }
        else
        {
            this.currentState = EnemyStates.Defend;
        }


    }

    public virtual void DefendBuilding()
    {
        Debug.Log("Defending...");
    }

    public virtual void Run()
    {
        if (health <= 3)
        {
            this.GetComponent<NavMeshAgent>().SetDestination(RandomNavmeshLocation(20));
        }
        Debug.Log("Running...");
    }

    public virtual void SearchforBuilding()
    {
        canSeeBuilding = true;
    }
    public GameObject FindClosestPlayer()
    {
        GameObject[] allPlayers;
        allPlayers = GameObject.FindGameObjectsWithTag("Mage");
        canSeePlayer = true;
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = this.transform.position;
        foreach (GameObject currentPlayer in allPlayers)
        {
            Vector3 differenceBetweenPlayer = currentPlayer.transform.position - position;
            float curDistance = differenceBetweenPlayer.sqrMagnitude;
            if (curDistance < distance)
            {


                closest = currentPlayer;
                distance = curDistance;
                this.currentState = EnemyStates.Attack;
            }
            else
            {
                this.currentState = EnemyStates.SearchforClosestBuilding;
            }
            this.GetComponent<NavMeshAgent>().SetDestination(closest.transform.position);

        }
        return closest;
    }



    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

}

