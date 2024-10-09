using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f; // Speed of the player

    void Update()
    {
        // Get input for horizontal (left/right) and vertical (up/down) movement
        float horizontal = Input.GetAxis("Horizontal"); // Left (-1) and Right (+1)
        float vertical = Input.GetAxis("Vertical"); // Down (-1) and Up (+1)

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
