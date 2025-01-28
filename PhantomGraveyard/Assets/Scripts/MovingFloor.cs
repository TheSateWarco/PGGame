using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{

    [SerializeField] private float acceleration = 2f; // Rate of acceleration
    [SerializeField] private float deceleration = 1f; // Rate of deceleration
    [SerializeField] private float multiplier = 10;
    [SerializeField] private float maxSpeed = 10f;    // Maximum speed
    [SerializeField] private float currentSpeed = 5f; // Current speed
    [SerializeField] private GameObject currentFloor; // Assign the floor object in the Inspector
    [SerializeField] private GameObject prevFloor;
    [SerializeField] private float threshold = 20f; // Set the threshold value
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
        if (currentFloor.transform.position.x > threshold)
        {
            Debug.Log("The" + currentFloor + "passed below the threshold!");
            currentFloor.transform.position = new Vector3(prevFloor.transform.position.x - 30, prevFloor.transform.position.y, prevFloor.transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime * multiplier;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            currentSpeed -= deceleration * Time.deltaTime * multiplier * multiplier;
        }
        else
        {
            // Decelerate when 'W' is not pressed
            currentSpeed -= deceleration * Time.deltaTime * multiplier;
        }

        // Clamp the speed to stay within [5, maxSpeed]
        currentSpeed = Mathf.Clamp(currentSpeed, 5, maxSpeed);


    }
}








