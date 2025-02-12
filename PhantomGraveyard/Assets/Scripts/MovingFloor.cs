using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour {
    [SerializeField] private float acceleration = 2f;  // Rate of acceleration
    [SerializeField] private float deceleration = 1f;  // Rate of deceleration
    [SerializeField] private float multiplier = 10f;   // Multiplier for acceleration/deceleration
    [SerializeField] private float maxSpeed = 10f;     // Maximum speed
    [SerializeField] private float currentSpeed = 5f;  // Current speed
    [SerializeField] private GameObject currentFloor;  // Floor object
    [SerializeField] private GameObject prevFloor;     // Previous floor object
    [SerializeField] private float threshold = 20f;    // Threshold for resetting floor position
    [SerializeField] private FirstPOV firstPOV;        // Reference to FirstPOV script
    [SerializeField] private float xSize;               // size of x
    [SerializeField] private bool right = true;        // size of x
    [SerializeField] private bool rotate = false;

    void Start() {
        if (firstPOV == null) {
            firstPOV = FindObjectOfType<FirstPOV>();  // Automatically find the FirstPOV component
        }

    }

    void Update() {
        
        // Moving the floor to the right based on current speed
        if (right && !rotate) {
            transform.Translate(Vector3.right * Time.deltaTime * currentSpeed);
        } else if (!right && !rotate){
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed);
        }
        else if (right && rotate)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        }
        else if (right && !rotate)
        {
            transform.Translate(Vector3.back * Time.deltaTime * currentSpeed);
        }

        // Check if current floor has passed the threshold
        if (currentFloor.transform.position.x > threshold && rotate) {
            Debug.Log("The " + currentFloor.name + " passed below the threshold!");
            // Reset floor position relative to the previous floor
            currentFloor.transform.position = new Vector3(prevFloor.transform.position.x + xSize, prevFloor.transform.position.y, prevFloor.transform.position.z);
        }
        else if (currentFloor.transform.position.z < threshold && !rotate)
        {
            // Reset floor position relative to the previous floor
            currentFloor.transform.position = new Vector3(prevFloor.transform.position.x, prevFloor.transform.position.y, prevFloor.transform.position.z + xSize);
        }

        // Speed control: Increase speed when W is pressed, decrease with S
        if (Input.GetKey(KeyCode.W)) {
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.deltaTime * multiplier * multiplier);
        } else if (Input.GetKey(KeyCode.S)) {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 5f, deceleration * Time.deltaTime * multiplier * multiplier);  // Minimum speed (5)
        }
        else{
            // Logic for resetting or slowing down the floor
            // You might want to add more behavior here as needed
            currentSpeed = Mathf.MoveTowards(currentSpeed, 5f, deceleration * Time.deltaTime * multiplier);
        }

        // Clamp the speed to stay within [5, maxSpeed]
        currentSpeed = Mathf.Clamp(currentSpeed, 5, maxSpeed);

        // Apply camera shake effect if firstPOV is assigned
        if (firstPOV != null) {
            firstPOV.ChangeShake(currentSpeed / (maxSpeed*1.5f), currentSpeed / (maxSpeed * 1.5f));
        }
        

    }
}


