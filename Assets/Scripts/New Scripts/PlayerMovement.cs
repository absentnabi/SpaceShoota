using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



[System.Serializable]
public class Boundary1
{
    public float xMin, xMax, zMin, zMax;
}



public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Boundary1 boundary1;

    public GameObject shot;
    public Transform shotSpawn;
    
    public float fireRate;
    public float nextFire;

    private AudioSource weaponFire;
    
    
    // Start is called before the first frame update
    void Start()
    {
        weaponFire = GetComponent<AudioSource>();
    }
    
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            weaponFire.Play(0);

        }
        
        
        
        
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        
        GetComponent<Rigidbody>().velocity = movement * movementSpeed;
        
        //Debug.Log("position: " + GetComponent<Rigidbody>().position);
        Debug.Log("position X: " + GetComponent<Rigidbody>().position.x);
        Debug.Log("position Z: " + GetComponent<Rigidbody>().position.z);

        /*if (GetComponent<Rigidbody>().position.z < zMin || GetComponent<Rigidbody>().position.z > zMax)
        {
            Debug.Log("ERROR! Remain in designated Z area!");
        }
        else if (GetComponent<Rigidbody>().position.x < xMin || GetComponent<Rigidbody>().position.x > xMax)
        {
            Debug.Log("ERROR! Remain in designated X area!");
        }*/
        
        // limit player movement to remain on screen
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary1.xMin, boundary1.xMax), 
            0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary1.zMin, boundary1.zMax));
        
    }
    
}
