using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    //if the driver object collides with anything in the world
    //the moveSpeed is changed to the value of slowSpeed
     void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    //if the driver object runs over the booster sprite
    //the moveSpeed is changed to the value of boostSpeed
     void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "booster")
        {
            moveSpeed = boostSpeed;
        }
    }
}
