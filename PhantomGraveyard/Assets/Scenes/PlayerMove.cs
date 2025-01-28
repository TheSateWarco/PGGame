using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private GameObject player;
    private bool right = true;
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) && right)
        {
            player.transform.position = new Vector3(-15f, 0f, -moveDistance);
            right = false;
        }
        if (Input.GetKey(KeyCode.D) && !right)
        {
            player.transform.position = new Vector3(-15f, 0f, moveDistance);
            right = true;
        }
    }
}
