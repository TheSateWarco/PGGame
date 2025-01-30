using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

using UnityEngine;

public class ScrollBG : MonoBehaviour {
    [SerializeField] private float scrollSpeed = 2f;
    private Vector3 startPos;
    private float resetPosition = -30; // Adjust this based on sprite width
    private float threshold = -100;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        Debug.Log(transform.position);
        // Move the background leftward
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Reset the background position when it moves out of view
        if (transform.position.x < threshold) {
            transform.position = new Vector3(resetPosition, yPos, zPos);
        }
    }
}