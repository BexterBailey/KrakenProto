using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenMover : MonoBehaviour
{
    public Transform player;    // Assign the player's transform in the Inspector
    public float speed = 20f;    // Speed of movement
    public float stoppingDistance = 1f; // Minimum distance to stop moving
    private Animator animator;  // Animator reference

    void Start()
    {
        // Get the Animator component attached to the object
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calculate the direction from the object to the player
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the object is close enough to stop
        if (distance > stoppingDistance)
        {
            // Move the object towards the player
            transform.position += direction * speed * Time.deltaTime;

            animator.SetBool("Walk_Cycle_1", true);
        }
        else
        {
            // Stop the movement when close enough to the player
            animator.SetBool("Walk_Cycle_1", false);
        }
    }
}
