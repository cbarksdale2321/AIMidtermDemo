using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float cameraSensitivity = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(new Vector3(0, cameraSensitivity, 0));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -cameraSensitivity, 0));
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(new Vector3(-cameraSensitivity, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(new Vector3(cameraSensitivity, 0, 0));
        }

    }
}

