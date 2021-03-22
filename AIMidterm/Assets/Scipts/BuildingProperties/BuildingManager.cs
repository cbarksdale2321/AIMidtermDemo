using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]
    int health;
    [SerializeField]
    GameObject[] allBuildings;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach  (GameObject building in allBuildings)
        {
            building.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject building in allBuildings)
        {
            building.tag = "Building";
            

            if (health <= 6)
            {
                building.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (health <= 3)
            {
                building.GetComponent<Renderer>().material.color = Color.red;
            }
            if (health <=0)
            {
                building.SetActive(false);
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SiegeWeapon")
        {
            health = health - 2;
        }
        
    }
}
