using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    //adding two color fields to our Delivery Driver Script
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    bool hasPackage = false; //hasPackage variable to track if the player has a package

    //initialize our spriteRenderer variable to store the reference
    SpriteRenderer spriteRenderer;

    //at the beginning of the scene our game finds spriteRenderer and assigns it the SpriteRenderer component
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    //everytime the Delivery Driver object collides with something else
    //in the world it prints this out
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("we are colliding!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //conditional statement that says if the player enters through
        //a package object in the world and doesnt already have a package
        //we print out that the player
        //has picked up the package and set the hasPackage variable to true
        //changes color to value of hasPackageColor
        //then destroy the package gameObject 
        if(other.tag == "package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.5f);
        }

        //if the player enters through a customer object in our world
        //and hasPackage is true, then we print out that the customer
        //has recieved the package and set the state of hasPackage back
        //to false so they cant exploit anything
        //then we change the color to noPackageColor
        if(other.tag == "customer" && hasPackage)
        {
            Debug.Log("customer recieved package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
