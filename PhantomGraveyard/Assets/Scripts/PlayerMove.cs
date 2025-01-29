using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveDistance = 20f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject player;
    private int multiplier = 5;
    private Vector3 targetPosition;
    private bool right = true;
    private bool isMoving = false;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && right && !isMoving)
        {
            targetPosition = transform.position + Vector3.back * moveDistance;
            StartCoroutine(MoveToPosition());
            right = false;
        }
        if (Input.GetKey(KeyCode.D) && !right && !isMoving)
        {
            targetPosition = transform.position + Vector3.forward * moveDistance;
            StartCoroutine(MoveToPosition());
            right = true;
        }
    }


    IEnumerator MoveToPosition() {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f) {
            // Smoothly interpolate position towards target
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime * multiplier);
            yield return null;
        }

        transform.position = targetPosition; // Ensure exact final position
        isMoving = false;
    }
}
