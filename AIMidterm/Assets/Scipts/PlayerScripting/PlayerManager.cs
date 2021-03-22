using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject playerMage;
    [SerializeField] GameObject playerWarrior;
    [SerializeField] GameObject playerArcher;
    [SerializeField] GameObject playerSeigeWeapon;
    [SerializeField] Transform homeBase;


    public static GameObject controlledUnit; // instead of GameObject, could use custom type like ControllableUnit

    void Start()
    {
        controlledUnit = null;
    }

    // Update is called once per frame
    void Update()
    {

       

            var input = Input.inputString;
            switch (input)
            {
                case "1":
                    Instantiate(playerWarrior, homeBase.position, Quaternion.identity);
                    break;
                case "2":
                    Instantiate(playerMage, homeBase.position, Quaternion.identity);
                    break;
                case "3":
                    Instantiate(playerArcher, homeBase.position, Quaternion.identity);
                    break;
                case "4":
                    Instantiate(playerSeigeWeapon, homeBase.position, Quaternion.identity);
                    break;

            }
        }
    }



        
    
