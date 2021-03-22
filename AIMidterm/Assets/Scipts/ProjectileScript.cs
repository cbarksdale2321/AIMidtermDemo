using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    GameObject Base;
    GameObject[] mages;
    EnemyMage mageScript;
    //shoot projectile if enemy is close enough to either a player or building
    // Start is called before the first frame update
    void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Building");
        mages = GameObject.FindGameObjectsWithTag("Mage");
        mageScript = GetComponent<EnemyMage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        foreach (GameObject mage in mages)
        {
            if (mageScript.currentState == EnemyStates.Attack)
            {
                Instantiate(this.gameObject, mage.transform.position, Quaternion.identity);
                Vector3.Lerp(this.transform.position, Base.transform.position, Time.deltaTime);
            }
        }
        
    }
}
