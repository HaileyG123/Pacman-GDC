using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class packman : MonoBehaviour
{
    float speed = 30;
    private Vector3 position;
    
    //boundary condition
    float xBoundary = 54f;

    float zBoundary = 50f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        Move();
        Boundary();
        transform.position = position;
    }

    //handles player movement
    private void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            position += Vector3.back * speed * Time.deltaTime;
        }
    }
    
    //checks if pacman goes passed the game boundary and adjusts accordingly
    private void Boundary()
    {
        //X boundary check
        if (position.x > xBoundary)
        {
            position.x = xBoundary;
        }
        else if (this.transform.position.x < -xBoundary)
        {
            position.x = -xBoundary;
        }
        
        //z boundary check
        if (position.z > zBoundary)
        {
            position.z = zBoundary;
        }
        else if (position.z < -zBoundary)
        {
            position.z = -zBoundary;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "orb")
        {
            other.gameObject.SetActive(false);
        }
    }
}
