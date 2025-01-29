using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class FirstPOV : MonoBehaviour {
    [SerializeField] private float sensitivity = 200f;  // Mouse sensitivity
    [SerializeField] private Transform playerBody;      // Reference to player object
    [SerializeField] private MovingFloor floor;      // floor moving script
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private Cinemachine.CinemachineBasicMultiChannelPerlin perlin;  // Perlin Noise component

    private float xRotation = 0f;     // Keep track of vertical rotation
    private float yRotation = 0f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        // Access the Cinemachine Perlin component attached to the virtual camera
        perlin = virtualCamera.GetComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        if (perlin == null) {
            perlin = FindObjectOfType<Cinemachine.CinemachineBasicMultiChannelPerlin>();  // Automatically find the FirstPOV component
        }
    }

    private void Update() {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Adjust rotations
        xRotation -= mouseY; // Invert Y for natural look movement
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping
        

        yRotation += mouseX; // Accumulate rotation instead of resetting
        yRotation = Mathf.Clamp(yRotation, -120f, 30f); // Prevent flipping
        // Apply rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); // Rotate camera properly
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f); // Rotate player body


    }

    public void ChangeShake(float intensity, float frequency) {
        // Scale the intensity and frequency with some noise for more variation
        perlin.m_AmplitudeGain = intensity * Random.Range(0.8f, 1.2f);  // Adding random fluctuation
        perlin.m_FrequencyGain = frequency * Random.Range(0.9f, 1.1f);  // Slight variation in shake frequency

    }
}