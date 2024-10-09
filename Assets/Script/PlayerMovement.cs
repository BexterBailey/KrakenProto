using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 100f; // Speed of the player
    public float rotateSpeed = 100f;

    void Update()
    {
        // Get input for horizontal (left/right) and vertical (up/down) movement
        float horizontal = Input.GetAxis("Horizontal"); // Left (-1) and Right (+1)
        float vertical = Input.GetAxis("Vertical"); // Down (-1) and Up (+1)

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction * speed * Time.deltaTime);

	//Vector3 heading = new Vector3(moveHorizontal, 0.0f, moveVertical);
	
	//transform.rotation = Quaternion.LookRotation(heading);
	//transform.Translate (movement * movementSpeed * Time.deltaTime, Space.World);

	if (Input.GetKey(KeyCode.A))
	transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
	else if (Input.GetKey(KeyCode.D))
	transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
