using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float inputThreshold = 0.1f; // Input threshold

    private int facingDirection = 1; // 1 = right, -1 = left

    void Start()
    {
        // Determine initial facing direction based on localScale.x
        // Use Mathf.Sign for consistent handling with SetFacingDirection
        facingDirection = (int)Mathf.Sign(transform.localScale.x);
        if (facingDirection == 0) facingDirection = 1; // Default to right if scale is 0
    }

    void Update()
    {
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Moving right
        if (horizontalInput > inputThreshold)
        {
            SetFacingDirection(1);
        }
        // Moving left
        else if (horizontalInput < -inputThreshold)
        {
            SetFacingDirection(-1);
        }
    }

    // Set character facing direction
    public void SetFacingDirection(int direction)
    {
        // Only flip when direction changes
        if (direction != facingDirection)
        {
            facingDirection = direction;

            // Use localScale.x for flipping (consistent with firearrow.cs)
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * facingDirection;
            transform.localScale = scale;

            // Debug output
            Debug.Log($"Character direction updated: {facingDirection}, localScale.x: {transform.localScale.x}");
        }
    }

    // Get current facing direction (for other scripts)
    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
