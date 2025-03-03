using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    // Adjust this value to control the rotation speed
    public float turnSpeed = 20f;
    private Vector3 tapPosition = Vector3.zero;
    [SerializeField] PlayerLife playerLife;

    void Update()
    {
        // Check if the player has tapped the screen
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get the position of the tap in world coordinates
            tapPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            tapPosition.z = transform.position.z; // Maintain the same z-coordinate
        }

        Vector3 direction = tapPosition - transform.position;
        direction.Normalize();

        transform.up = Vector2.MoveTowards(transform.up, direction, Time.deltaTime * turnSpeed);
    }
}
